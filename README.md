Проект создан на движке unity 2021.3.13f1
Основной рабочий уровень на данный момент Level_1 в папке Assets.
Все рабочие файлы и скрипты находятся Assets\Serman.
Сама сцена Level_1 пустая, и имеет только один объект со скриптом загрузки.
Массив в этом скрипте, это список объектов, которые будут динамически загружены.
 Все объекты грузятся как bundles. Для того чтобы объекты стали bundles,
 нужно прифаб добавить в Addressables.
Действующие прифабы которые учувствуют в сцене лежат в папке Assets\Serman\Prefabs\Addressables_Obj
При билде проекта создаются bundles, из можно взять в папке EIMOLAD_NEW\ServerData\WebGL
Существует скрипт на языке JS для связи игры с WebReact находится Assets\Plugins
Передача данных между игрой и WebReact в ту или другую стороны, происходит в формате json.