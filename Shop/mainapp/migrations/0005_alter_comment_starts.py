# Generated by Django 4.2.2 on 2023-08-01 15:32

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('mainapp', '0004_alter_comment_starts'),
    ]

    operations = [
        migrations.AlterField(
            model_name='comment',
            name='starts',
            field=models.CharField(choices=[('1', '1'), ('4', '4'), ('3', '3'), ('5', '5'), ('2', '2')], default='1', max_length=20),
        ),
    ]
