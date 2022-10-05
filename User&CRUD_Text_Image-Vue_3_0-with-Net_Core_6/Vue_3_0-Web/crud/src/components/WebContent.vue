<template>
    <!--illegal auth alert-->
    <div id="ErrorAlert" class="alert alert-danger alert-dismissible" style="padding: 2%; z-index: 5; width: 60%; max-width: 60%; left: 20%; font-size: 2.5vw; display: none; top: 0; position: fixed; border: 2vw inset #D63333; border-radius: 2em; margin-top: 4%;">
        <strong>Error!</strong>
        <div style="font-size: 2vw;">
            <span id="ErrorAlertMsg"></span><br>
            Expired or Illegal Authentication,<br> Please Log-in first.<br>
            5'Sec Later Will Direct To Log-in Page.
        </div>
    </div>
    <!--log out check message-->
    <div id="LogOutWarn" class="alert alert-warning alert-dismissible" style="padding: 2%; z-index: 5; width: 60%; height: fit-content; left: 20%; font-size: 3vw; top: 20%; position: fixed; border-radius: 2em; display: none">
        <strong>Warning!</strong>
        <div style="font-size: 2.5vw; width: 100%;">
            <br>
            You're now log out,
            <br>
            Really wanna Log out ??
            <div style="display: inline-block; width: 100%; margin-top: 6%;">
                <button class="btn btn-info btn-logout" @click="LogOut();" style="margin-right:20%;">Yes</button><button class="btn btn-danger btn-logout" @click="closeAlert();">No</button>
            </div>
        </div>
    </div>
    <div id="all">
        <!--Title bar-->
        <div class="TitleBar">
            <span class="En"><strong>Vue 3.0 with .Net Core 6 API - CRUD</strong></span>
        </div>

        <!--log out button-->
        <button class="LogOut" @click="showCheckAlert();" title="Log Out"><span class="glyphicon">&#xe163;</span></button>

        <img alt="logo" src="@/assets/logo-1.png">
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
        <!--user info、icon-->
        <div class="UserInfo">
            <span class="glyphicon glyphicon-user" style="margin-bottom: 2%; font-size: 2vw;"><span id="UserAccount" class="Ch" style="font-size: 2vw;"></span></span>
            <p>
                <span class="Ch" style="font-size: 1.5vw;">Permissive Action : </span>&emsp;
                <span class="label label-primary Ch" style="margin: 1%; width: auto; font-size: 1.1vw; height: fit-content; padding: 0.8%; border-radius: 5em; ">Get</span>
                <span id="PostTag" class="label label-success Ch" style="margin: 1%; width: auto; font-size: 1.1vw; height: fit-content; padding: 1.2%; border-radius: 5em; display: none; ">Post</span>
                <span id="PutTag" class="label label-warning Ch" style="margin: 1%; width: auto; font-size: 1.1vw; height: fit-content; padding: 1.2%; border-radius: 5em; display: none; ">Put</span>
                <span id="DeleteTag" class="label label-danger Ch" style="margin: 1%; width: auto; font-size: 1.1vw; height: fit-content; padding: 1.2%; border-radius: 5em; display: none; ">Delete</span>
            </p>
        </div>

        <!--container block-->
        <div class="ContentBlock">
            <div class="HoriContainer" ref="HoriContainer">

                <!--crud text contain-->
                <div class="container" style="min-width: 80vw;">
                    <div class="SubTitleBar" @click="HoriContainer('right');">
                        <strong>
                            <span class="glyphicon">&#xe127;</span>&nbsp;CRUD WITH IMAGE&nbsp;<span class="glyphicon">&#xe127;</span>
                        </strong>
                    </div>
                    <!--Get All-->
                    <div class="accordion">
                        <input type="checkbox" id="GetAll">
                        <div class="ActionText" style="background: #4682B4;">
                            <label for="GetAll">Get&emsp;<span class="URLText" style="border: 2px inset #4682B4;">/api/DataBase</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody">No parameter.</div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('GetAll_ErrorMsg','GetAll_Response'); GetAll();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <pre id="GetAll_Response" class="RespMsg"></pre><!--successful-->
                                <div id="GetAll_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Post-->
                    <div class="accordion" id="PostBar" style="display: none">
                        <input type="checkbox" id="Post">
                        <div class="ActionText" style="background: #46B482; ">
                            <label for="Post">Post&emsp;<span class="URLText" style="border: 2px inset #46B482;">/api/DataBase</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Data : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="PostData" placeholder="Data type is string">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('Post_ErrorMsg','Post_Response'); Post();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <pre id="Post_Response" class="RespMsg"></pre><!--successful-->
                                <div id="Post_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Get Data By Id-->
                    <div class="accordion">
                        <input type="checkbox" id="Get">
                        <div class="ActionText" style="background: #4682B4;">
                            <label for="Get">Get&emsp;<span class="URLText" style="border: 2px inset #4682B4;">/api/DataBase/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="GetId" placeholder="Id type is byte">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('Get_Response','Get_ErrorMsg'); Get();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <pre id="Get_Response" class="RespMsg"></pre><!--successful-->
                                <div id="Get_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Update Data By Id-->
                    <div class="accordion" id="PutBar" style="display: none">
                        <input type="checkbox" id="Put">
                        <div class="ActionText" style="background: #E69138;">
                            <label for="Put">Put&emsp;<span class="URLText" style="border: 2px inset #E69138;">/api/DataBase/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="PutId" placeholder="Id type is byte">
                                    <span class="input-group-addon En ParaLabel"><strong>Data : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="PutData" placeholder="Data type is string">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('Put_ErrorMsg','Put_Response'); Put();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <pre id="Put_Response" class="RespMsg"></pre><!--successful-->
                                <div id="Put_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Delete Data By Id-->
                    <div class="accordion" id="DeleteBar" style="display: none">
                        <input type="checkbox" id="Delete">
                        <div class="ActionText" style="background: #D63333;">
                            <label for="Delete">Delete&emsp;<span class="URLText" style="border: 2px inset #D63333;">/api/DataBase/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="DeleteId" placeholder="Id type is byte">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('Delete_Response','Delete_ErrorMsg'); Delete();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <pre id="Delete_Response" class="RespMsg"></pre><!--successful-->
                                <div id="Delete_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                </div>
                
                <!--crud image contain-->
                <div class="container" style="min-width: 80vw;">
                    <div class="SubTitleBar" @click="HoriContainer();">
                        <strong>
                            <span class="glyphicon">&#xe128;</span>&nbsp;CRUD WITH TEXT&nbsp;<span class="glyphicon">&#xe128;</span>
                        </strong>
                    </div>
                    <!--Get All Image-->
                    <div class="accordion">
                        <input type="checkbox" id="GetAllImage">
                        <div class="ActionText" style="background: #00CED1; ">
                            <label for="GetAllImage">Get&emsp;<span class="URLText" style="border: 2px inset #00CED1; ">/api/Image</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody">No parameter.</div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('GetAllImage_ErrorMsg','GetAllImage_Response'); GetAllImage();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <div ref="GetAllImage_Response" id="GetAllImage_Response" class="RespImg"></div><!--successful-->
                                <div ref="GetAllImage_ErrorMsg" id="GetAllImage_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Post Image-->
                    <div class="accordion" id="PostImageBar" style="display: none">
                        <input type="checkbox" id="PostImage">
                        <div class="ActionText" style="background: #008B8B; ">
                            <label for="PostImage">Post&emsp;<span class="URLText" style="border: 2px inset #008B8B; ">/api/Image</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody FileGroup">
                                    <div class="FileBorderBlock" ref="FileBorderBlock">
                                        <div class="FileUploadBlock" ref="FileUploadBlock">
                                            <input type="file" id="PostFiles" ref="PostFiles" multiple accept="image/jpeg" @change="GetAllFiles()" @dragover="DragOver()" @dragleave="DragLeave()" @drop="Drop()"/>
                                            <div class="FileUploadBlockDesc">
                                                <span class="glyphicon" style="font-size: 5vw;">&#xe198;</span><br><br>
                                                <a class="ChooseTest">Choose Files</a> or drag it here.
                                            </div>
                                        </div>
                                        <div class="FileDisplayBorderBlock" ref="FileDisplayBorderBlock">
                                            <div class="ImageCancelIcon" @click="RemoveImages()"><span class="glyphicon" title="Remove Images">&#xe088;</span></div>
                                            <div class="FileDisplayBlock" ref="FileDisplayBlock"></div>
                                        </div>
                                    </div>
                                </div>    
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('PostImage_ErrorMsg','PostImage_Response'); PostImage();">Execute</button>
                            </div>
                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <div id="PostImage_Response" ref="PostImage_Response" class="RespText"></div><!--successful-->
                                <div id="PostImage_ErrorMsg" ref="PostImage_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Get Image By Id-->
                    <div class="accordion">
                        <input type="checkbox" id="GetImage">
                        <div class="ActionText" style="background: #00CED1; ">
                            <label for="GetImage">Get&emsp;<span class="URLText" style="border: 2px inset #00CED1; ">/api/Image/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="GetImageId" ref="GetImageId" placeholder="Id type is byte">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('GetImage_Response','GetImage_ErrorMsg'); GetImage();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <div id="GetImage_Response" ref="GetImage_Response" class="RespImg"></div><!--successful-->
                                <div id="GetImage_ErrorMsg" ref="GetImage_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Update Image By Id-->
                    <div class="accordion" id="PutImageBar" style="display: none">
                        <input type="checkbox" id="PutImage">
                        <div class="ActionText" style="background: #FF6347; ">
                            <label for="PutImage">Put&emsp;<span class="URLText" style="border: 2px inset #FF6347; ">/api/Image/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group" ref="PutFileBorderBlock">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="PutImageId" ref="PutImageId" @change="AblePutFile();" placeholder="Id type is byte">
                                    &nbsp;&nbsp;&nbsp;<span ref="PutFileBlockFinger" class="glyphicon" style="font-size: 2.3vw; color: #FF6347; opacity:0.5;"><strong>&#xe127;</strong></span>&nbsp;&nbsp;&nbsp;
                                    <label for="PutFile" class="ParaButton" ref="PutFileBlock">
                                        <span class="PutFileDesc">Browse File</span>
                                        <input type="file" ref="PutFile" id="PutFile" style="visibility:hidden;" @change="GetFile();">
                                    </label>
                                </div>
                                <div class="Tbody SingleFileDisplayBlock" ref="DisplayPutImageBlock">
                                    <div ref="SingleDisplayBlock" style="height:40vh; width: 60vw; display: flex; justify-content: center; padding-bottom: 0;"></div>
                                    <div class="ImageCancelIcon" @click="RemoveImage()"><span class="glyphicon" title="Remove Image">&#xe088;</span></div>
                                    
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('PutImage_ErrorMsg','PutImge_Response'); PutImage();">Execute</button>
                            </div>
                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <div id="PutImge_Response" ref="PutImge_Response" class="RespText"></div><!--successful-->
                                <div id="PutImage_ErrorMsg" ref="PutImage_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                    <!--Delete Image By Id-->
                    <div class="accordion" id="DeleteImageBar" style="display: none">
                        <input type="checkbox" id="DeleteImage">
                        <div class="ActionText" style="background: #DB7093; ">
                            <label for="DeleteImage">Delete&emsp;<span class="URLText" style="border: 2px inset #DB7093; ">/api/Image/{Id}</span></label>
                        </div>
                        <div class="p">
                            <hr /><span class="Ch Thead"><strong>Parameters</strong></span><hr />
                            <div class="Para">
                                <div class="Tbody input-group">
                                    <span class="input-group-addon En ParaLabel"><strong>Id : </strong></span>
                                    <input type="text" class="form-control ParaInput" id="DeleteImageId" ref="DeleteImageId" placeholder="Id type is byte">
                                </div>
                                <button class="btn btn-primary ExecuteBtn" @click="InitDiv('DeleteImage_Response','DeleteImaeg_ErrorMsg'); DeleteImage();">Execute</button>
                            </div>

                            <hr /><span class="Ch Thead"><strong>Response</strong></span><hr />
                            <div class="Resp">
                                <div id="DeleteImage_Response" ref="DeleteImage_Response" class="RespText"></div><!--successful-->
                                <div id="DeleteImaeg_ErrorMsg" ref="DeleteImaeg_ErrorMsg" class="ErrorMsg"></div><!--error msg-->
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <!--參考資料區塊-->
        <div class="Reference">
            <span class="En"><strong>Reference</strong></span>
            <ul>
                <li><a href="https://www.youtube.com/watch?v=GdWrYfDfqRE&list=PL4cUxeGkcC9gCtAuEdXTjNVE5bbMFo5OD&index=5&ab_channel=TheNetNinj" target="_blank" rel="noopener">Vue & Typescript tutorial</a></li>
                <li><a href="https://medium.com/web-design-zone/vue-js-%E4%BD%BF%E7%94%A8vue-cli%E5%AE%89%E8%A3%9D-vue3-f54d05ef348e" target="_blank" rel="noopener">Vue CLI install Vue 3.0</a></li>
                <li><a href="https://vuejs.org/guide/typescript/overview.html#ide-support" target="_blank" rel="noopener">Vue with Typescript</a></li>
            </ul>
            <ul>
                <li><a href="https://blog.logrocket.com/axios-vs-fetch-best-http-requests/" target="_blank" rel="noopener">Reason to use axios</a></li>
                <li><a href="https://kalacloud.com/blog/vue3-typescript-axios/" target="_blank" rel="noopener">Vue with axios</a></li>
            </ul>
            <ul>
                <li><a href="https://www.w3schools.com/bootstrap4/tryit.asp?filename=trybs_spinners_grow&stacked=h" target="_blank" rel="noopener">bootstrap</a></li>
                <li><a href="https://freefrontend.com/css-accordions/" target="_blank" rel="noopener">css accordion</a></li>
            </ul>

        </div>
        <!--底部時間-->
        <div class="FixedBar">
            <span id="Timer" class="En"><strong>{{Timer}}</strong></span>
        </div>
    </div>

</template>

<script lang="ts">
    import { defineComponent, ref } from 'vue';
    import DataService from '@/services/DataService'
    import ImageService from '@/services/ImageService'
    import Data from '@/types/Data'
    import Images from '@/types/Images'
    import ResponseData from '@/types/ResponseData'
    export default defineComponent({
        name: 'WebContent',
        setup() {
            const Image = ref<Images>()
            const Images = ref<Images[]>([])
            const Data = ref<Data[]>([])
            const TimerId = ref<number | undefined>(0)
            const Timer = ref<string | null>(// < genericz泛型 >, ( default value )
                new Date().toLocaleString("en-US", {
                    year: 'numeric', month: 'long', day: 'numeric',
                    hour: '2-digit', minute: '2-digit', second: '2-digit',
                    timeZoneName: 'long'
                })
            )
            return { Timer, TimerId, Data, Images, Image }// 初始值
        },
        methods: {// function區塊
            InitDiv(...DivId: string[]) {// 刷空訊息欄位
                DivId.forEach((item) => {
                    document.getElementById(item)!.innerHTML = ""
                })
            },
            HoriContainer(Direct: string) {
                let HorizontalContainer = (this.$refs.HoriContainer as HTMLDivElement);
                if (Direct == "right") {
                    HorizontalContainer!.scrollTo(HorizontalContainer!.offsetLeft + HorizontalContainer!.offsetWidth, 0);
                    return
                }
                HorizontalContainer!.scrollTo(0,0);
            },
            GetFile() {
                let PutFile = (this.$refs.PutFile as HTMLInputElement);
                if (PutFile!.files!.length <= 0) {
                    (this.$refs.PutImage_ErrorMsg as HTMLDivElement)!.innerHTML = "File Can't be null.";
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.pointerEvents = "auto";
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.pointerEvents = "auto";
                    return
                }
                if (PutFile!.files!.length > 1) {
                    (this.$refs.PutImage_ErrorMsg as HTMLDivElement)!.innerHTML = "File Can't More Than One.";
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.pointerEvents = "auto";
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.pointerEvents = "auto";
                    PutFile!.value = "";
                    return
                }
                this.DisplayFileInfo(PutFile!.files);
            },
            AblePutFile() {
                if ((this.$refs.PutImageId as HTMLInputElement)!.value != "") {
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.opacity = "1";
                    (this.$refs.PutFileBlock as HTMLLabelElement)!.style.pointerEvents = "auto";
                    (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.pointerEvents = "auto";
                    return
                }
                (this.$refs.PutFileBlock as HTMLLabelElement)!.style.opacity = "0.5";
                (this.$refs.PutFileBlock as HTMLLabelElement)!.style.pointerEvents = "none";
                (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.opacity = "0.5";
                (this.$refs.PutFileBlockFinger as HTMLLabelElement)!.style.pointerEvents = "none";
            },
            RemoveImage() {
                (this.$refs.PutFile as HTMLInputElement)!.value = "";

                (this.$refs.SingleDisplayBlock as HTMLDivElement)!.innerHTML = "";
                (this.$refs.DisplayPutImageBlock as HTMLDivElement)!.style.display = "none";

                (this.$refs.PutFileBorderBlock as HTMLDivElement)!.style.display = "flex";
            },
            RemoveImages() {
                (this.$refs.PostFiles as HTMLInputElement)!.value = "";

                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.border = "0.3vw dashed #008B8B";
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.backgroundColor = "#FCFCFC";

                (this.$refs.FileDisplayBlock as HTMLDivElement)!.innerHTML = "";
                (this.$refs.FileDisplayBorderBlock as HTMLDivElement)!.style.display = "none";

                (this.$refs.FileUploadBlock as HTMLDivElement)!.style.display = "flex";
            },
            DisplayFileInfo(File: FileList | null) {
                (this.$refs.PutFileBorderBlock as HTMLDivElement)!.style.display = "none";
                (this.$refs.DisplayPutImageBlock as HTMLDivElement)!.style.display = "flex";
                let DisplayBlock = (this.$refs.SingleDisplayBlock as HTMLDivElement);
                let ImgFrame = document.createElement("div");
                let Img = document.createElement("img");
                let ImgInfo = document.createElement("div");
                let PutDesc = document.createElement("div");
                Img!.src = window.URL.createObjectURL(File![0]);
                PutDesc!.innerHTML = "Replace ID-"+(this.$refs.PutImageId as HTMLInputElement)!.value+" Image width";
                PutDesc!.className = "ImgInfo";
                ImgFrame!.className = "ImgFrame";
                ImgInfo!.className = "ImgInfo";
                ImgInfo!.innerHTML = File![0]!.name;
                ImgFrame!.appendChild(PutDesc);
                ImgFrame!.appendChild(Img);
                ImgFrame!.appendChild(ImgInfo);
                DisplayBlock!.appendChild(ImgFrame);
                return
            },
            DisplayFilesInfo(Files: FileList | null) {
                (this.$refs.FileUploadBlock as HTMLDivElement)!.style.display = "none";
                (this.$refs.FileDisplayBorderBlock as HTMLDivElement)!.style.display = "flex";
                let DisplayBlock = (this.$refs.FileDisplayBlock as HTMLDivElement);
                for (let index = 0; index <= Files!.length; index++) {
                    if (Files![index]) {
                        let ImgFrame = document.createElement("div");
                        let Img = document.createElement("img");
                        let ImgInfo = document.createElement("div");
                        Img!.src = window.URL.createObjectURL(Files![index]);
                        ImgFrame!.className = "ImgFrame";
                        ImgInfo!.className = "ImgInfo";
                        ImgInfo!.innerHTML = Files![index]!.name;
                        ImgFrame!.appendChild(Img);
                        ImgFrame!.appendChild(ImgInfo);
                        DisplayBlock!.appendChild(ImgFrame);
                    }
                }
            },
            GetAllFiles() {
                if ((this.$refs.PostFiles as HTMLInputElement)!.files!.length <= 0) {
                    (this.$refs.PostImage_ErrorMsg as HTMLDivElement)!.innerHTML = "File Can't be null.";
                    (this.$refs.FileBorderBlock as HTMLDivElement)!.style.border = "0.3vw dashed #008B8B";
                    (this.$refs.FileBorderBlock as HTMLDivElement)!.style.backgroundColor = "#FCFCFC";
                    return
                }
                this.DisplayFilesInfo((this.$refs.PostFiles as HTMLInputElement)!.files)
            },
            DragOver() {
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.border = "0.4vw dotted #00BDBD";
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.backgroundColor = "rgb(0, 189, 189, 0.2)";
            },
            DragLeave() {
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.border = "0.3vw dashed #008B8B";
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.backgroundColor = "#FCFCFC";
            },
            Drop() {
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.border = "0.4vw inset #008B8B";
                (this.$refs.FileBorderBlock as HTMLDivElement)!.style.backgroundColor = "rgb(0, 189, 189, 0.2)";
            },
            StartLoading() {// 啟動等待效果
                let body = document.getElementById('Body')
                document.getElementById('spinnerGrop')!.style.display = "inline-flex"
                body!.style.opacity = "0.5"
                body!.style.overflow = "hidden"
                body!.style.cursor = "wait"
            },
            StopLoading() {// 停止等待效果
                let body = document.getElementById('Body')
                document.getElementById('spinnerGrop')!.style.display = "none"
                body!.style.opacity = "1"
                body!.style.overflow = "auto"
                body!.style.cursor = "default"
            },
            delay(milliseconds: number) {// 延遲效果
                return new Promise(resolve => {
                    setTimeout(resolve, milliseconds);
                });
            },
            closeAlert() {
                let Body = document.getElementById('Body')
                let body = document.getElementById('all')
                body!.style.opacity = "1"
                Body!.style.overflow = "auto"
                body!.style.cursor = "default"
                document.getElementById("LogOutWarn")!.style.display = "none"
            },
            showCheckAlert() {
                let Body = document.getElementById('Body')
                let body = document.getElementById('all')
                body!.style.opacity = "0.5"
                Body!.style.overflow = "hidden"
                body!.style.cursor = "wait"
                document.getElementById("LogOutWarn")!.style.display = "block"
            },
            showAlert() {
                let Body = document.getElementById('Body')
                let body = document.getElementById('all')
                body!.style.opacity = "0.5"
                Body!.style.overflow = "hidden"
                body!.style.cursor = "wait"
                document.getElementById('ErrorAlert')!.style.display = "block"
                setTimeout((time: number) => {
                    body!.style.opacity = "1"
                    Body!.style.overflow = "auto"
                    body!.style.cursor = "default"
                    this.$router.push("/login")
                }, 5000)
            },
            async LogOut() {
                this.closeAlert()
                this.StartLoading()
                await this.delay(1000)
                this.$route.params!.id = ""
                localStorage.removeItem('token')
                this.StopLoading()
                this.$router.push("/login")
            },
            async AuthCheck() {// 檢查憑證, 使用者權限
                this.StartLoading()
                await this.delay(1000);
                DataService.AuthCheck({Perm: 'perm'})
                    .then((response: ResponseData) => {
                        Object.values(response.data).forEach((item: any) => {
                            let Tag = document.getElementById((Object.values(item)[0]) as string + "Tag") as HTMLDivElement
                            let Bar = document.getElementById((Object.values(item)[0]) as string + "Bar") as HTMLDivElement
                            let ImageBar = document.getElementById((Object.values(item)[0]) as string + "ImageBar") as HTMLDivElement
                            let UserAccount = this.$route.params!.id
                            if (Object.values(item)[1]) {
                                console.log(UserAccount)
                                Tag!.style.display = "inline-block"
                                Bar!.style.display = "block"
                                ImageBar!.style.display = "block";
                                document.getElementById("UserAccount")!.innerHTML = " : " + ((UserAccount == "") ? "Anonmyous" : UserAccount.toString())
                            } else {
                                ImageBar!.style.display = "none";
                                Tag!.style.display = "none";
                            }
                        })
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        this.StopLoading()
                        document.getElementById("ErrorAlertMsg")!.innerHTML = e.message
                        this.showAlert()
                    })

              this.StopLoading()
            },
            async GetAll() {// 取得所有資料
                this.StartLoading()
                await this.delay(1000);
                document.getElementById('GetAll_Response')!.style.display = "none"
                DataService.GetAll()
                    .then((response: ResponseData) => {
                        this.Data = response.data
                        document.getElementById('GetAll_Response')!.style.display = "block"
                        this.Data.forEach((item) => {
                            document.getElementById('GetAll_Response')!.innerHTML += JSON.stringify(item, null, 2)
                        })
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        document.getElementById('GetAll_ErrorMsg')!.innerHTML = "Error: " + e.message
                        this.StopLoading()
                    })
            },
            async GetAllImage() {
                this.StartLoading();
                this.delay(1000);
                let ResText = (this.$refs.GetAllImage_Response as HTMLDivElement);
                ResText!.style.display = "none";
                ImageService.GetAllImage()
                    .then((response: ResponseData) => {
                        ResText!.style.display = "block";
                        this.Images = response.data;
                        this.Images.forEach((item) => {
                            let ImgBlock = document.createElement("div");
                            let ImgFrame = document.createElement("div");
                            let ImgId = document.createElement("div");
                            let ImgDateTime = document.createElement("div");
                            let Img = document.createElement("img");

                            ImgBlock!.className = "ImgBlock";
                            ImgFrame!.className = "ImgFrame";
                            ImgId!.className = "ImgInfo";
                            ImgDateTime!.className = "ImgInfo";

                            ImgId!.innerHTML = "ID-"+item.id;
                            Img!.src = ImageService.ImageBaseUrl + item.imageUrl;
                            ImgDateTime!.innerHTML = item.dateTime;

                            ImgFrame!.appendChild(ImgId);
                            ImgFrame!.appendChild(Img);
                            ImgFrame!.appendChild(ImgDateTime);

                            ImgBlock!.appendChild(ImgFrame);

                            ResText!.appendChild(ImgBlock);
                        });
                        this.StopLoading();
                    })
                    .catch((e: Error) => {
                        (this.$refs.GetAllImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: "+ e.message;
                        this.StopLoading()
                    })
            },
            async Post() {// 上傳新資料
                this.StartLoading()
                this.delay(1000);
                document.getElementById('Post_Response')!.style.display = "none"
                let val = document.getElementById('PostData') as HTMLInputElement | null
                if (val == null || val!.value == "") {
                    document.getElementById('Post_ErrorMsg')!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                DataService.Post({ data: val!.value, dateTime: val!.value })
                    .then((response: ResponseData) => {
                        this.Data = response.data
                        document.getElementById('Post_Response')!.style.display = "block"
                        this.Data.forEach((item) => {
                            document.getElementById('Post_Response')!.innerHTML += JSON.stringify(item, null, 2)
                        })
                        val!.value = ""
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        document.getElementById('Post_ErrorMsg')!.innerHTML = "Error: " + e.message
                        this.StopLoading()
                    })
            },
            async PostImage() {// 上傳新圖片
                this.StartLoading()
                this.delay(1000);
                let ResText = (this.$refs.PostImage_Response as HTMLDivElement);
                ResText!.style.display = "none";
                let Image = (this.$refs.PostFiles as HTMLInputElement);
                if (Image == null || Image!.files!.length <= 0) {
                    (this.$refs.PostImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Empty Not Allowed.";
                    this.StopLoading()
                    return
                }
                let Files = new FormData();
                for (let index = 0; index < Image!.files!.length; index++)
                    Files.append('Files', Image!.files![index]);
                ImageService.PostImage(Files)
                    .then((response: ResponseData) => {
                        ResText!.style.display = "block";
                        ResText!.innerHTML = response.data.toString();
                        this.RemoveImages();
                        this.StopLoading();
                    })
                    .catch((e: Error) => {
                        (this.$refs.PostImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: " + e.message;
                        this.RemoveImages();
                        this.StopLoading()
                    })
            },
            async Get() {// 取得資料
                this.StartLoading()
                this.delay(1000);
                document.getElementById('Get_Response')!.style.display = "none"
                let val = document.getElementById('GetId') as HTMLInputElement | null
                if (val == null || val!.value == "") {
                    document.getElementById('Get_ErrorMsg')!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                DataService.Get(val!.value)
                    .then((response: ResponseData) => {
                        this.Data = response.data
                        document.getElementById('Get_Response')!.style.display = "block"
                        document.getElementById('Get_Response')!.innerHTML += JSON.stringify(this.Data, null, 2)
                        val!.value = ""
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        document.getElementById('Get_ErrorMsg')!.innerHTML = "Error: " + e.message
                        this.StopLoading()
                    })
            },
            async GetImage() {
                this.StartLoading();
                this.delay(1000);
                let ResText = (this.$refs.GetImage_Response as HTMLDivElement);
                let GetImageId = (this.$refs.GetImageId as HTMLInputElement);
                ResText!.style.display = "none";
                if (GetImageId == null || GetImageId!.value == "") {
                    (this.$refs.GetImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                ImageService.GetImage(GetImageId!.value)
                    .then((response: ResponseData) => {
                        ResText!.style.display = "block";
                        this.Image = response.data;
                        let ImgBlock = document.createElement("div");
                        let ImgFrame = document.createElement("div");
                        let ImgId = document.createElement("div");
                        let ImgDateTime = document.createElement("div");
                        let Img = document.createElement("img");

                        ImgBlock!.className = "ImgBlock";
                        ImgFrame!.className = "ImgFrame";
                        ImgId!.className = "ImgInfo";
                        ImgDateTime!.className = "ImgInfo";

                        ImgId!.innerHTML = "ID-" + this.Image!.id;
                        Img!.src = ImageService.ImageBaseUrl + this.Image!.imageUrl;
                        ImgDateTime!.innerHTML = this.Image!.dateTime;

                        ImgFrame!.appendChild(ImgId);
                        ImgFrame!.appendChild(Img);
                        ImgFrame!.appendChild(ImgDateTime);

                        ImgBlock!.appendChild(ImgFrame);
                        ResText!.appendChild(ImgBlock);
                        
                        GetImageId!.value = "";
                        this.StopLoading();
                    })
                    .catch((e: Error) => {
                        (this.$refs.GetImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: " + e.message;
                        this.StopLoading()
                    })
            },
            async Put() {// 更新資料
                this.StartLoading()
                this.delay(1000);
                document.getElementById('Put_Response')!.style.display = "none"
                let valId = document.getElementById('PutId') as HTMLInputElement | null
                let valData = document.getElementById('PutData') as HTMLInputElement | null
                if (valId == null || valId!.value == "" || valData == null || valData!.value == "") {
                    document.getElementById('Put_ErrorMsg')!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                DataService.Update(valId!.value, { data: valData!.value, dateTime: valData!.value })
                    .then((response: ResponseData) => {
                        this.Data = response.data
                        document.getElementById('Put_Response')!.style.display = "block"
                        this.Data.forEach((item) => {
                            document.getElementById('Put_Response')!.innerHTML += JSON.stringify(item, null, 2)
                        })
                        valId!.value = ""
                        valData!.value = ""
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        document.getElementById('Put_ErrorMsg')!.innerHTML = "Error: " + e.message
                        this.StopLoading()
                    })
            },
            async PutImage() {
                this.StartLoading();
                this.delay(1000);
                let ResText = (this.$refs.PutImge_Response as HTMLDivElement);
                let PutImageId = (this.$refs.PutImageId as HTMLInputElement);
                let Image = (this.$refs.PutFile as HTMLInputElement);
                ResText!.style.display = "none";
                if (PutImageId == null || PutImageId!.value == "") {
                    (this.$refs.PutImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                if (Image == null || Image!.files!.length <= 0) {
                    (this.$refs.PutImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Empty Not Allowed.";
                    this.StopLoading()
                    return
                }
                let File = new FormData();
                File.append('File', Image!.files![0]);
                ImageService.UpdateImage(PutImageId!.value, File)
                    .then((response: ResponseData) => {
                        ResText!.style.display = "block";
                        ResText!.innerHTML = response.data.toString();
                        this.RemoveImage();
                        this.StopLoading();
                    })
                    .catch((e: Error) => {
                        (this.$refs.PutImage_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: " + e.message;
                        this.RemoveImage();
                        this.StopLoading()
                    })
            },
            async Delete() {// 刪除資料
                this.StartLoading()
                this.delay(1000);
                document.getElementById('Delete_Response')!.style.display = "none"
                let val = document.getElementById('DeleteId') as HTMLInputElement | null
                if (val == null || val!.value == "") {
                    document.getElementById('Delete_ErrorMsg')!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                DataService.Delete(val!.value)
                    .then((response: ResponseData) => {
                        this.Data = response.data
                        document.getElementById('Delete_Response')!.style.display = "block"
                        this.Data.forEach((item) => {
                            document.getElementById('Delete_Response')!.innerHTML += JSON.stringify(item, null, 2)
                        })
                        val!.value = ""
                        this.StopLoading()
                    })
                    .catch((e: Error) => {
                        document.getElementById('Delete_ErrorMsg')!.innerHTML = "Error: " + e.message
                        this.StopLoading()
                    })
            },
            async DeleteImage() {
                this.StartLoading();
                this.delay(1000);
                let ResText = (this.$refs.DeleteImage_Response as HTMLDivElement);
                let DeleteImageId = (this.$refs.DeleteImageId as HTMLInputElement);
                ResText!.style.display = "none";
                if (DeleteImageId == null || DeleteImageId!.value == "") {
                    (this.$refs.DeleteImaeg_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: input can't be null."
                    this.StopLoading()
                    return
                }
                ImageService.DeleteImage(DeleteImageId!.value)
                    .then((response: ResponseData) => {
                          ResText!.style.display = "block";
                          ResText!.innerHTML = response.data.toString();
                          this.StopLoading();
                      })
                    .catch((e: Error) => {
                        (this.$refs.DeleteImaeg_ErrorMsg as HTMLDivElement)!.innerHTML = "Error: " + e.message;
                        this.StopLoading()
                    })
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
        },
        mounted() {
            this.AuthCheck()
        }
    });
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
    .btn-logout {
        width: 20%;
        font-size: 1vw;
    }

    .accordion {
        opacity: 0.9;
    }
        .accordion:hover {
            opacity: 1;
        }

    .LogOut {
        margin: 2% 3% 0% 0%;
        top: 0;
        right: 0;
        position: fixed;
        font-size: 2.4vw;
        padding: 1.7vh 1vw 0.5vh 1vw;
        border: 0.24vw outset #ece6d9;
        border-radius: 55%;
        background-color: rgba(224, 215, 194, 0.4);
        transition: all 0.3s ease-in-out;
    }
        .LogOut:hover {
            background-color: rgba(248, 246, 241, 0.4);
            border: 0.24vw outset #ece6d9;
            border-radius: 50em;
        }

        .LogOut:active {
            border: 0.01vw outset #ece6d9;
            background-color: rgba(248, 246, 241, 0.2);
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
        font-size: 1.5vw;
    }
</style>
