import { createRouter, createWebHashHistory } from 'vue-router'
import WebContent from '@/components/WebContent.vue'
import LoginPage from '@/components/LoginPage.vue'
import NotFound from '@/components/NotFound.vue'

const routes = [
    {
        path: `/crud/:id`,
        name: "WebContent",
        component: WebContent
    },
    {
        path: "/login",
        name: "LoginPage",
        component: LoginPage
    },
    {
        path: "/:catchAll(.*)",
        component: NotFound,
    }
];

const router = createRouter({
    history: createWebHashHistory(),
    routes: routes,
});

export default router;