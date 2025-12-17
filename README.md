# gm-project

Demo project (react, typescript, C#, frontend, backend, MS-SQL)

![Site top bar](/demoAssets/TopBarScreenshot.png)
### Preview изображения элементов сайта можно посмотреть [тут](https://github.com/omix60572/gm-project/tree/main/demoAssets/previewImages)

### Структура проекта Backend:

```txt
# Solution root
-- Components
-- [Общие компоненты системы]
-- [...]
# Startup services:
-- Services                         | Запускаемые сервисы
--- GM.MessagingBackendService      | Запуск backend'a для обработки очередей rabbitMQ
# Main startup projects:
- GM.WebApiStartup                  | Запуск web API для работы frontend'a
```

### Для запуска frontend'а:

```cmd
cd GMFrontend
npm install
npm run dev
```

### Источник для демо assets (демо список популярных фильмов): Сайт [IXBT Games Блоги Live](https://www.ixbt.com/live/movie/10-samyh-luchshih-filmov-po-ocenkam-na-imdb-zolotaya-desyatka-kino-za-vsyu-istoriyu-kinoindustrii.html)
