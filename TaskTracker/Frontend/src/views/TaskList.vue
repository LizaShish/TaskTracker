<template>
  <div>
    <div>
      <h1>Task List</h1>
      <router-link to="/new">➕ Add Task</router-link>
    </div>

    <ul>
      <li v-for="task in tasks" :key="task.id">
        <span v-if="editingTaskId !== task.id">{{ task.name }}</span>
        <input v-else v-model="editedTaskName" />

        <button v-if="editingTaskId !== task.id" @click="startEditing(task)">Редактировать</button>
        <button v-else @click="saveTask(task)">Сохранить</button>

        <button @click="deleteTask(task.id)">Удалить</button>
      </li>
    </ul>
  </div>
</template>

<script>
import axios from 'axios';

export default {
  name: 'TaskList',
  data() {
    return {
      tasks: [],
      newTaskName: '',
      editingTaskId: null,
      editedTaskName: ''
    };
  },
  mounted() {
    this.loadTasks();
  },
  methods: {
    baseUrl() {
      return import.meta.env.VITE_API_BASE_URL;
    },
    loadTasks() {
      axios.get(`${this.baseUrl()}/api/task`)
          .then(res => {
            this.tasks = res.data;
          })
          .catch(err => {
            console.error('Ошибка загрузки задач:', err);
          });
    },
    addTask() {
      if (!this.newTaskName.trim()) return;
      axios.post(`${this.baseUrl()}/api/task`, { name: this.newTaskName })
          .then(() => {
            this.newTaskName = '';
            this.loadTasks();
          })
          .catch(err => {
            console.error('Ошибка добавления задачи:', err);
          });
    },
    startEditing(task) {
      this.editingTaskId = task.id;
      this.editedTaskName = task.name;
    },
    saveTask(task) {
      axios.put(`${this.baseUrl()}/api/task/${task.id}`, { name: this.editedTaskName })
          .then(() => {
            this.editingTaskId = null;
            this.editedTaskName = '';
            this.loadTasks();
          })
          .catch(err => {
            console.error('Ошибка сохранения задачи:', err);
          });
      console.log('Payload перед отправкой:', this.task);
      taskService.create(this.task)
    },
    deleteTask(id) {
      axios.delete(`${this.baseUrl()}/api/task/${id}`)
          .then(() => {
            this.loadTasks();
          })
          .catch(err => {
            console.error('Ошибка удаления задачи:', err);
          });
    }
  }
};
</script>

<style scoped>
input {
  margin-right: 8px;
}
button {
  margin-left: 4px;
}
</style>