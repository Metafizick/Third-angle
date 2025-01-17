# Generated by Django 4.2.2 on 2023-07-10 20:27

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('basketapp', '0001_initial'),
    ]

    operations = [
        migrations.AlterField(
            model_name='basket',
            name='status',
            field=models.CharField(choices=[('Готов к отгрузке', 'Готов к отгрузке'), ('Закрыт', 'Закрыт'), ('Ожидает', 'Ожидает'), ('В обработке', 'В обработке')], default='Ожидает', max_length=20),
        ),
        migrations.AlterField(
            model_name='request',
            name='status',
            field=models.CharField(choices=[('Готов к отгрузке', 'Готов к отгрузке'), ('Закрыт', 'Закрыт'), ('Ожидает', 'Ожидает'), ('В обработке', 'В обработке')], default='Ожидает', max_length=20),
        ),
    ]
