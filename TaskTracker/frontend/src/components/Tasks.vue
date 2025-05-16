<template>
  <div>
    <h1>Tasks</h1>
    <ul>
      <li v-for="task in tasks" :key="task.taskId">
        {{ task.title }} - {{ task.status }}
      </li>
    </ul>
  </div>
</template>

<script setup>
import { ref, onMounted} from 'vue';

const tasks = ref([]);

onMounted(async () => {
  try{
    const response = await fetch('http://localhost:5174/api/tasks');
    if(!response.ok)throw new Error('Network response was not ok');
    tasks.value = await response.json();
  } catch(error){
    console.log(error);
  }
});
</script>