import axios from 'axios';

const API_URL = 'https://localhost:7184/api/task'; 

export default {
    async getAll() {
        const res = await axios.get(API_URL);
        return res.data;
    },
    async getById(id) {
        const res = await axios.get(`${API_URL}/${id}`);
        return res.data;
    },
    async create(task) {
        await axios.post(API_URL, task);
    },
    async update(task) {
        await axios.put(API_URL, task);
    },
    async remove(id) {
        await axios.delete(`${API_URL}/${id}`);
    }
};