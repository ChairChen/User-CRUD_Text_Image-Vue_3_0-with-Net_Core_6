<template>
    <!--Title bar-->
    <div class="TitleBar">
        <span class="En"><strong>Vue 3.0 with .Net Core 6 API - Home</strong></span>
    </div>

    <div id="Info" class="alert alert-info alert-dismissible" style="max-width:60%; left:20%; font-size: 1.2vw; display: none">
        <button type="button" class="close" @click="closeAlert('Info');"><h1><strong>&times;</strong></h1></button>
        <strong>Info!</strong>
        <div id="StatusInfo">
            You're now logging in CRUD.
        </div>
    </div>

    <div id="Error" class="alert alert-danger alert-dismissible" style="max-width: 60%; left: 20%; font-size: 1.2vw; display: none">
        <button type="button" class="close" @click="closeAlert('Error');"><h1><strong>&times;</strong></h1></button>
        <strong>Error!</strong>
        <div id="StatusError">
        </div>
    </div>

    <div class="LoginFrame">
        <div class="Frame">
            <div style="height:fit-content">
                <img alt="logo" src="@/assets/logo-1.png" style="height: 15vh;width: 10vw;">&emsp;
                <div style="display: inline-block; white-space: nowrap; vertical-align:middle; width: 50%; overflow: hidden; text-overflow: ellipsis;">
                    <span id="Status" style="font-weight: bolder; cursor:pointer;" title="Show Message." @click="showStatus();">Log-in</span>
                </div>
            </div>
            <hr />
            <span class="UserLabel" for="Account"><strong>Account : </strong></span>
            <input v-model="Account" type="text" class="UserInput" id="Account" placeholder="Enter your account">
            <span id="AccountWarn" class="glyphicon" style="color: #D63333; display:none;">&#xe129;&emsp;Account cant be empty.</span>

            <br><hr />
            <span class="UserLabel" for="Password"><strong>Password : </strong></span>
            <input v-model="Password" type="password" class="UserInput" id="Password" placeholder="Enter your password">
            <span id="PasswordWarn" class="glyphicon" style="color: #D63333; display: none;">&#xe129;&emsp;Password cant be empty.</span>
            <br><hr />
            <button class="SubmitBtn" @click="Login();" id="Submit">Submit</button>
        </div>
    </div>
    <!--loading spinner-->
    <div class="spinnerGrop" id="spinnerGrop">
        <div class="spinner-grow text-primary BigSpinner"></div>
        <div class="spinner-grow text-success BigSpinner"></div>
        <div class="spinner-grow text-warning BigSpinner"></div>
        <div class="spinner-grow text-danger BigSpinner"></div>
    </div>
    <!--Background Cloud animation-->
    <div class="BackgroundCloud">
        <div class="clouds">
            <img src="@/assets/Cloud-1.png">
            <img src="@/assets/Cloud-3.png">
            <img src="@/assets/Cloud-2.png">
            <img src="@/assets/Cloud-3.png">
            <img src="@/assets/Cloud-1.png">
            <img src="@/assets/Cloud-3.png">
            <img src="@/assets/Cloud-2.png">
            <img src="@/assets/Cloud-1.png">
            <img src="@/assets/Cloud-3.png">
            <img src="@/assets/Cloud-2.png">
        </div>
    </div>
    <!--參考資料區塊-->
    <div class="Reference">
        <span class="En"><strong>Reference</strong></span><br><br>
        <ul>
            <li><a href="https://www.youtube.com/watch?v=fhWIkbF18lM&ab_channel=PatrickGod" target="_blank" rel="noopener">NET 6 & JWT tutorial</a></li>
            <li><a href="https://kalacloud.com/blog/vue-router-tutorial-for-vue-3/" target="_blank" rel="noopener">Vue Router</a></li>
            <li><a href="https://ithelp.ithome.com.tw/articles/10202949" target="_blank" rel="noopener">Vue Entity: Hook Event</a></li>
        </ul>
        <ul>
            <li><a href="https://vueschool.io/articles/vuejs-tutorials/how-to-use-vue-router-a-complete-tutorial/" target="_blank" rel="noopener">Install Router</a></li>
            <li><a href="https://www.ifreesite.com/color/" target="_blank" rel="noopener">color</a></li>
        </ul>
        <ul>
            <li><a href="https://medium.com/%E6%8B%89%E6%8B%89%E7%9A%84%E7%A8%8B%E5%BC%8F%E7%AD%86%E8%A8%98/vue-router-hash-history-mode-d02175eb0d7c" target="_blank" rel="noopener">Router history</a></li>
        </ul>
    </div>
    <!--底部時間-->
    <div class="FixedBar">
        <span id="Timer" class="En"><strong>{{Timer}}</strong></span>
    </div>
</template>

<script lang="ts">
    import { defineComponent, ref } from 'vue';
    import UserService from '@/services/UserService'
    import User from '@/types/User'
    import ResponseData from '@/types/ResponseData'

    export default defineComponent({
        name: 'LoginPage',
        props: {
            msg: String,
        },
        setup() {
            var Account = ref<string>("")
            var Password = ref<string>("")
            const User = ref<User>()
            const TimerId = ref<number | undefined>(0)
            const Timer = ref<string | null>(// < genericz泛型 >, ( default value )
                new Date().toLocaleString("en-US", {
                    year: 'numeric', month: 'long', day: 'numeric',
                    hour: '2-digit', minute: '2-digit', second: '2-digit',
                    timeZoneName: 'long'
                })
            )
            return { Timer, TimerId, Account, Password, User }// 初始值
        },
        methods: {// function區塊
            StartLoading() {// 啟動等待效果
                let body = document.getElementById('Body')
                document.getElementById('spinnerGrop')!.style.display = "inline-flex"
                body!.style.opacity = "0.5"
                body!.style.overflow = "hidden"
                body!.style.cursor = "wait"
                // login登入按鈕
                let SubmitBtn = document.getElementById("Submit")
                SubmitBtn!.style.backgroundColor = "rgba(248, 246, 241, 0.4)"
                SubmitBtn!.style.pointerEvents = "none"
            },
            StopLoading() {// 停止等待效果
                let body = document.getElementById('Body')
                document.getElementById('spinnerGrop')!.style.display = "none"
                body!.style.opacity = "1"
                body!.style.overflow = "auto"
                body!.style.cursor = "default"
                // login登入按鈕
                let SubmitBtn = document.getElementById("Submit")
                SubmitBtn!.style.backgroundColor = "rgba(224, 215, 194, 0.4)"
                SubmitBtn!.style.pointerEvents = "auto"
            },
            Navigate(Account: string) {
                this.$router.push({
                    name: 'WebContent',
                    params: { id: Account.trim() }
                });
            },
            IsEmpty(...input: any[]): boolean {
                let result = true;
                input.forEach((item: string) => {
                    if (Object.values(item)[0] == "") {
                        document.getElementById(Object.keys(item)[0] + "Warn")!.style.display = "inline-flex";
                        document.getElementById("Status")!.style.color = "#D63333"
                        document.getElementById("Status")!.innerHTML = "Empty Not Allow"
                        result = false
                    }
                    else document.getElementById(Object.keys(item)[0] + "Warn")!.style.display = "none";
                })
                return result
            },
            closeAlert(div: string) {
                document.getElementById(div)!.style.display = "none"
            },
            showStatus() {
                if (document.getElementById("StatusError")!.innerHTML.trim() != "") {
                    document.getElementById("Error")!.style.display = "block"
                } else document.getElementById("Info")!.style.display = "block"
            },
            async Login() {
                if (!this.IsEmpty({ "Account": this.Account }, { "Password": this.Password }))
                    return
                this.StartLoading()
                await this.delay(1000)
                let id = this.Account
                UserService.Login({ Account: this.Account, Password: this.Password })
                    .then((response: ResponseData) => {
                        document.getElementById("Status")!.style.color = "#4682B4"
                        document.getElementById("Status")!.innerHTML = "Welcome"
                        this.User = response.data
                        localStorage.setItem('token', this.User!.token)
                        this.StopLoading()
                        this.Navigate(id)
                    })
                    .catch((e: Error) => {
                        document.getElementById("Status")!.style.color = "#D63333"
                        document.getElementById("Status")!.innerHTML = e.message
                        document.getElementById("StatusError")!.innerHTML = e.message
                        this.StopLoading()
                    })
                document.getElementById("Status")!.style.color = "black"
                document.getElementById("Status")!.innerHTML = "Log-in"
                this.Account = ""
                this.Password = ""
            },
            delay(milliseconds: number) {// 延遲效果
                return new Promise(resolve => {
                    setTimeout(resolve, milliseconds);
                });
            },
            DisplayTimer() {// 列出時間
                this.Timer = new Date().toLocaleString("en-US", {
                    year: 'numeric', month: 'long', day: 'numeric',
                    hour: '2-digit', minute: '2-digit', second: '2-digit',
                    timeZoneName: 'long'
                })
                return this.Timer
            },
            StartTimer() {// 開始計時
                this.TimerId = setInterval(() => this.DisplayTimer(), 1000);
            },
            StopTimer() {// 停止interval計時
                clearInterval(this.TimerId);
            }
        },
        created() {
            this.StartTimer()
        }
    });
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .SubmitBtn {
        margin-top: 2%;
        padding: 1%;
        font-size: 85%;
        width: fit-content;
        background-color: rgba(224, 215, 194, 0.4);
        border: 0.3vw outset #ece6d9;
        border-radius: 10%;
        transition: all 0.1s ease-in-out;
    }
        .SubmitBtn:hover {
            background-color: rgba(248, 246, 241, 0.4);
            border: 0.3vw outset #ece6d9;
            border-radius: 15%;
        }
        .SubmitBtn:active {
            border: 0.1vw outset #ece6d9;
            background-color: rgba(248, 246, 241, 0.2);
        }

    .LoginFrame {
        margin-top: 5%;
        display: flex;
        z-index: 3; /* 最上層*/
        top: 50%;
        left: 0;
        width: 100%;
        justify-content: center;
    }

    .Frame {
        font-size: 2.5vw;
        width: 50%;
        border: 0.3vw inset #ece6d9;
        border-radius: 3em;
        background-color: rgba(224, 215, 194, 0.4);
        padding: 2%;
    }

    .UserInput {
        padding-left: 2%;
        font-size: 90%;
        border: 0;
        background-color: rgba(236, 230, 218, 0.1);
        position: relative;
        width: 60%;
        transition: all 0.5s ease-in-out;
    }

    .UserInput:focus {
        border-radius: 1em;
        background-color: rgba(255, 255, 255, 0.4);
        outline: none !important;
    }

    .UserLabel {
        margin-left: 6%; 
        width: 10%;
    }

    h2 {
        margin: 40px 0 20px 0;
    }

    ul {
        list-style-type: none;
        padding: 0;
    }

    li {
        display: inline-block;
        margin: 0 10px;
    }

    a {
        color: #42b983;
        font-size: 1vw;
    }
</style>
