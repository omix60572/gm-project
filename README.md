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
-- BackgroundServices                   | Запускаемые сервисы
--- GM.MessagingBackendService          | Запуск backend'a для обработки очередей rabbitMQ
# Main startup projects:
- GM.WebApiStartup                      | Запуск web API для работы frontend'a
```

### Для запуска frontend'а:

```cmd
cd GMFrontend
npm install
npm run dev
```

### Источник для демо assets (демо список популярных фильмов, SQLite файл БД): Сайт [IXBT Games Блоги Live](https://www.ixbt.com/live/movie/10-samyh-luchshih-filmov-po-ocenkam-na-imdb-zolotaya-desyatka-kino-za-vsyu-istoriyu-kinoindustrii.html)

### Appsettings.json (формат файла и необходимые настройки):
- SqlSettings (обязательно к заполнению как и само подключение так и тип используемгого БД провайдера)
- RemoteModuleSettings (на данный момент нет реализации модуля)
- MessagingSettings (касается backend messaging сервиса и web api, хранит строку подключения к rabbitmq)
- JwtSettings (обязательно к заполнению, хранит секретный ключ для выдачи и валидации токенов в web api) (Key значение должно быть минимум из 16 символов)
- Kestrel (стандартный и обязательный элемент для запуска web api)

### Особенности работы с токенами:
- При выдаче токена получаем имя приложения которое запрашивает токен
- Имя приложения для которого может быть выдан токен хранится в таблице Applications
- Информация о выданных токенах записывается в таблицу ApplicationTokens (на каждое приложение с определенным application name выдается только один действующий токен)
