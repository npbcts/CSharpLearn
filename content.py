#! /usr/bin/python
# -*- coding: utf-8 -*-
"""
此python脚本用于自动生成学习笔记目录
"""
import re
import os
from typing import List, Dict

# 纳入目录的文件格式应为 字母+数字+文件名


def save_text(text, filename, mode='a', encoding='utf-8'):
    with open(filename, mode=mode, encoding=encoding) as f:
        f.write(text)
        f.close()


def parser_filename(filename: str, index: int, practic_folder: Dict[str, List[str]]):
    # 这里通过函数修改了practic_folder可变数据类型，而不是返回值
    chapter_index_tmp = re.findall(r'\d', filename)
    chapter_part_tmp = re.match(r'^[a-zA-Z]*', filename)
    if chapter_index_tmp and chapter_part_tmp:
        chapter_index = chapter_index_tmp[0]
        chapter_part = chapter_part_tmp[0]
        chapter_text = f"{chapter_index}. [{filename.split('.')[0]}]({filename})  \n"
        practic_folder.setdefault(chapter_part, []).append(chapter_text)


def content(content_name):
    files = os.listdir('.')
    files.sort()
    index = 0
    practic_folder = {}
    for file in files:
        parser_filename(file, index, practic_folder)

    if practic_folder:
        for key, value in practic_folder.items():
            value.sort()
            save_text(f'\n\n### {key} 部分\n', content_name)
            for index, file in enumerate(value):
                save_text(file, content_name)


if __name__ == '__main__':
    content_name = 'csharp笔记-000目录.md'
    if os.path.exists(content_name):
        os.remove(content_name)
    content(content_name)
    print('目录生成成功!')
