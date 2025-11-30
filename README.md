# gm-project

Demo project (react, typescript, C#, frontend, backend, MS-SQL)

![Site top bar](/demoAssets/TopBarScreenshot.png)

### Структура проекта Backend:

```txt
# Solution root
-- Components
-- [Общие компоненты системы]
# Startup projects:
- GM.StartupUI      | Запуск web API для работы frontend'a
- GM.RabbitBackend  | Запуск backend'a для обработки очередей rabbitMQ
```

### Для запуска frontend'а:

```cmd
cd GMFrontend
npm install
npm run dev
```
