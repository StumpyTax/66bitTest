import { createRouter, createWebHashHistory } from 'vue-router';
var routes = [
    {
        path: '/',
        name: 'home',
        component: function () { return import(/* webpackChunkName: "about" */ '../views/HomeView.vue'); }
    },
    {
        path: '/AddPlayer',
        name: 'addPlayer',
        // route level code-splitting
        // this generates a separate chunk (about.[hash].js) for this route
        // which is lazy-loaded when the route is visited.
        component: function () { return import(/* webpackChunkName: "about" */ '../views/PostView.vue'); }
    }
];
var router = createRouter({
    history: createWebHashHistory(),
    routes: routes
});
export default router;
//# sourceMappingURL=index.js.map