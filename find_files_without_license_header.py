import os

def file_list_rec(dir):
	file_list = list()
	for (dir_path, dir_names, file_names) in os.walk(dir):
		file_list.append(os.path.join(dir_path, file) for file in file_names)
		
LICENSE_HEADER = """/*
    SteelQuiz - A quiz program designed to make learning words easier
    Copyright (C) 2019  Steel9Apps

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/"""
		
working_dir = os.path.dirname(os.path.realpath(__file__))
files = file_list_rec(working_dir)
files_no_header = list()

for file in files:
	if not LICENSE_HEADER in open(file).read():
		files_no_header.append(file)
		
print('Files with missing license header:\n\n')
print(''.join(files_no_header))