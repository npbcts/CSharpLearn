#! /usr/bin/python
# -*- coding: utf-8 -*-
"""
此python脚本用于自动生成学习笔记目录
"""
import re
import os


section_dic = {0:'前言', 1: '一', 2: '二', 3: '三', 4: '四', 5: '五', 6: '六', 7: '七', 8: '八', 9:'九'}

def save_text(text, filename, mode='a', encoding='utf-8'):
    with open(filename, mode=mode, encoding=encoding) as f:
        f.write(text)
        f.close()

def content(content_name):
    files = os.listdir('.')
    files.sort()
    index = 0
    session_index = 0
    practic_folder = []
    for file in files:
        chapter_index = re.findall(r'\d', file)
        if chapter_index:
            if file.startswith('csharp'):
                session_index_tmp = int(chapter_index[0])
                if session_index != session_index_tmp:
                    session_index = session_index_tmp
                    content_str = f'\n\n### 第{section_dic.get(session_index)}部分\n'
                    save_text(content_str, content_name)
                
                index += 1
                chapter_text = f"{index}. [{file.split('.')[0]}]({file})  \n"
                save_text(chapter_text, content_name)
            else:
                practic_folder.append(file)
        
    # 添加练习程序文件夹目录
    save_text('\n\n### 练习程序列表\n', content_name)
    if practic_folder:
        for index, file in enumerate(practic_folder):
            save_text( f'{index+1}. [{file}]({file})\n', content_name)



if __name__ == '__main__':
    content_name = 'csharp笔记-000目录.md'
    if os.path.exists(content_name):
        os.remove(content_name)
    save_text('## CSharpLearn笔记目录\n', content_name)
    save_text('\n\n### 前言部分\n', content_name)
    content(content_name)
    print('目录生成成功!')
