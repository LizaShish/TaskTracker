Backend (ASP.NET Core)
-Откройте решение в Visual Studio\Rider.

-Установите зависимости через NuGet 

-Файл launchSettings.json должен содержать корректные порты (https://localhost:7184).

-Запустите backend (API доступен по адресу: https://localhost:7184/api/task или в зависимости от настроек)


Frontend (Vue 3 + Vite)

-Перейдите в папку frontend: cd Frontend  (она нахотся \TaskTracker\TaskTracker\Frontend  
 понимаю, что так быть не должно, но иначе Rider не видел папку)

-Установите зависимости: npm install

-Запусти фронтенд-приложение: npm run dev

-В выпадающей информации в терминале появится ссылка, 
которую нужно открыть в браузере


SQL-запросы:
1. Выводим задачи за последние 7 дней
SELECT *
FROM Tasks
WHERE CreateDate >= DATEADD(DAY, -7, GETDATE());

2. Выводим пользователей, у которых больше всего задач (CreateBy)
   SELECT CreateBy, COUNT(*) AS CreatedTasks
   FROM Tasks
   GROUP BY CreateBy
   ORDER BY CreatedTasks DESC;

3. Подсчитаем количество задач по каждому статусу
   SELECT Status, COUNT(*) AS TaskCount
   FROM Tasks
   GROUP BY Status
   ORDER BY TaskCount DESC;


Для проекта используется Firebird SQL. Скрипт для создания таблиц находится в папке:
\TaskTracker\Docs