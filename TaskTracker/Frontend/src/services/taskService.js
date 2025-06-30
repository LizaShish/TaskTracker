import axios from 'axios';

const API = axios.create({
    baseURL: '/api/task',
    headers: {
        'Content-Type': 'application/json'
    }
});

export default {
    async getAll() {
        const res = await API.get('/');
        return res.data;
    },
    async getById(id) {
        const res = await API.get(`/${id}`);
        return res.data;
    },
    async create(task) {
        await API.post('/', task);
    },
    async update(task) {
        await API.put('/', task);
    },
    async remove(id) {
        await API.delete(`/${id}`);
    }
};