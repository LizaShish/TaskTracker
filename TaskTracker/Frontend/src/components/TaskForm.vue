<template>
  <div>
    <h2>Создание новой задачи</h2>
    <form @submit.prevent="saveTask">
      <label>Название:</label>
      <input v-model="task.title" required />

      <label>Описание:</label>
      <textarea v-model="task.description"></textarea>

      <label>Статус:</label>
      <select v-model="task.status">
        <option>To Do</option>
        <option>In Progress</option>
        <option>Done</option>
      </select>

      <label>Кем создано:</label>
      <input v-model="task.createBy" />

      <label>Назначено на:</label>
      <input v-model="task.assignedTo" />

      <button type="submit">Сохранить</button>
    </form>
  </div>
</template>

<script>
import axios from '@/services/taskService.js';

export default {
  name: 'AddTask',
  data() {
    return {
      task: {
        id: null,
        title: '',
        description: '',
        status: 'To Do',
        createBy: '',
        assignedTo: '',
      },
    };
  },
  methods: {
    saveTask() {
      axios
          .create( this.task)
          .then(() => {
            alert('Задача создана!');
            this.resetForm();
          })
          .catch((error) => {
            console.error(error);
            alert('Ошибка при создании задачи.');
          });
    },
    resetForm() {
      this.task = {
        id: null,
        title: '',
        description: '',
        status: 'To Do',
        createBy: '',
        assignedTo: '',
      };
    },
  },
};
</script>

<style scoped>
form {
  display: flex;
  flex-direction: column;
  gap: 10px;
}
</style>