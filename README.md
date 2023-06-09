# Варіант 3. Змінити атрибути файлів в каталозі.

Ця програма дозволяє змінювати атрибути файлів у каталозі на основі заданого шаблону файлів.

## Використання

- `<directory>`: Шлях до каталогу, в якому знаходяться файли.
- `<file_template>`: Шаблон файлу для пошуку файлів у каталозі (наприклад, `*.txt`).
- `-h`: (Необов'язково) Змінити атрибут "прихований "атрибут файлів.
- `-r`: (Необов'язково) Змінити атрибут "тільки для читання" для файлів.
- `-a`: (Необов'язково) Змінити атрибут "архівний" для файлів.

Якщо під час запуску програми буде вказано неіснуючий каталог, відбудеться наступне: Оскільки каталогу не існує, програма згенерує виключення. Програма перехопить виняток і виведе повідомлення про помилку, яке вказує на те, що вказаний каталог не існує: `An error occurred: Could not find a part of the path`

Якщо аргументи командного рядка не вказано, програма запитає необхідну інформацію в інтерактивному режимі.

## Приклади

- Змінинти атрибути "прихований" і "доступний лише для читання" файлів `.md` у поточному каталозі:

`lab4.exe . *.md -r -h`
