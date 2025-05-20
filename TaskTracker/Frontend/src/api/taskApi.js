import axios from 'axios';

const api = axios.create({
    baseURL: 'https://localhost:7184/api/task',
    headers: {
        'Content-Type': 'application/json'
    }
});

export default {
    getAll: () => api.get('/'),
    getById: (id) => api.get(`/${id}`),
    create: (task) => api.post('/', task),
    update: (task) => api.put('/', task),
    remove: (id) => api.delete(`/${id}`),
    filter: (status, assignedTo) =>
        api.get(`/filter?status=${status}&assignedTo=${assignedTo}`)
};