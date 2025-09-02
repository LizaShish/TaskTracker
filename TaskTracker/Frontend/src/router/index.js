import { createRouter, createWebHistory } from 'vue-router';
import TaskList from '../views/TaskList.vue';
import TaskForm from '../components/TaskForm.vue';

const routes = [
    { path: '/', name: 'Home', component: TaskList },
    { path: '/new', name: 'NewTask', component: TaskForm },
    { path: '/edit/:id', name: 'EditTask', component: TaskForm, props: true },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;