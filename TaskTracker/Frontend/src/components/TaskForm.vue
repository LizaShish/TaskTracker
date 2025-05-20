<template>
  <div>
    <h2>{{ isEdit ? 'Редактировать' : 'Добавить' }} задачу</h2>
    <form @submit.prevent="save">
      <input v-model="task.title" placeholder="Название" required />
      <textarea v-model="task.description" placeholder="Описание" />
      <select v-model="task.status">
        <option value="To Do">To Do</option>
        <option value="In Progress">In Progress</option>
        <option value="Done">Done</option>
      </select>
      <input v-model="task.createBy" placeholder="Создана кем" />
      <input v-model="task.assignedTo" placeholder="Назначена на" />
      <button type="submit">Сохранить</button>
    </form>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import taskService from '../services/taskService';

const router = useRouter();
const route = useRoute();

const isEdit = !!route.params.id;
const task = ref({
  id: '',
  title: '',
  description: '',
  status: 'To Do',
  createBy: '',
  assignedTo: '',
  createDate: '',
  updateDate: ''
});

onMounted(async () => {
  if (isEdit) {
    const existingTask = await taskService.getById(route.params.id);
    task.value = { ...existingTask };
  }
});

const save = async () => {
  if (isEdit) {
    await taskService.update(task.value);
  } else {
    await taskService.create(task.value);
  }
  router.push('/');
};
</script>