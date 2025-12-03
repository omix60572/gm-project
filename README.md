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

### Источник для демо assets (демо список популярных фильмов): Сайт [IXBT Games Блоги Live](https://www.ixbt.com/live/movie/10-samyh-luchshih-filmov-po-ocenkam-na-imdb-zolotaya-desyatka-kino-za-vsyu-istoriyu-kinoindustrii.html)
