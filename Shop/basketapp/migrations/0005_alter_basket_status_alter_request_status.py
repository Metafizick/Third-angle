# Generated by Django 4.2.2 on 2023-07-30 15:24

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('basketapp', '0004_alter_basket_status_alter_request_status'),
    ]

    operations = [
        migrations.AlterField(
            model_name='basket',
            name='status',
            field=models.CharField(choices=[('Ожидает', 'Ожидает'), ('Готов к отгрузке', 'Готов к отгрузке'), ('Закрыт', 'Закрыт'), ('В обработке', 'В обработке')], default='Ожидает', max_length=20),
        ),
        migrations.AlterField(
            model_name='request',
            name='status',
            field=models.CharField(choices=[('Ожидает', 'Ожидает'), ('Готов к отгрузке', 'Готов к отгрузке'), ('Закрыт', 'Закрыт'), ('В обработке', 'В обработке')], default='Ожидает', max_length=20),
        ),
    ]
