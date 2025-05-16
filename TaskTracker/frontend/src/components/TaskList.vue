<template>
  <div>
    <h2>Список задач</h2>
    <ul>
      <li v-for="task in tasks" :key="task.taskId">
        {{ task.title }} ({{ task.status }})
      </li>
    </ul>
  </div>
</template>

<script>
import { getTasks } from '../services/taskService';

export default {
  data() {
    return {
      tasks: []
    };
  },
  async created() {
    const response = await getTasks();
    this.tasks = response.data;
  }
};
</script>