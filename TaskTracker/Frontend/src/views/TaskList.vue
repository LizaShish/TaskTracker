<template>
  <div>
    <h1>Task List</h1>
    <router-link to="/new">➕ Add Task</router-link>
    <ul v-if="tasks.length">
      <li v-for="task in tasks" :key="task.id">
        <b>{{ task.title }}</b> — {{ task.status }}
        <router-link :to="'/edit/' + task.id">✏️</router-link>
        <button @click="deleteTask(task.id)">🗑 Delete</button>
      </li>
    </ul>
  </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import taskService from '../services/taskService';

const tasks = ref([]);

onMounted(async () => {
  tasks.value = await taskService.getAll();
});

const deleteTask = async (id) => {
  await taskService.remove(id);
  tasks.value = tasks.value.filter(t => t.id !== id);
};
</script>