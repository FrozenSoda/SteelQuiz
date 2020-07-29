What is the difference between update_meta.xml and update_meta2.xml?

update_meta.xml:
The metadata file for updates, that was used before SteelQuiz stopped auto-updating to new major releases. Now SteelQuiz will ask first, even if automatic updates are enabled. To ensure v4.3.3, that asks before installing major updates, is installed before further major updates, all new major updates after SteelQuiz 4 is put into update_meta2.xml.

update_meta2.xml:
The new metadata file for updates, that should be used for major releases starting with SteelQuiz 5.


What is the difference between update_pkg.zip and update_pkg2.zip?

update_pkg.zip is the update package referenced by update_meta.xml
update_pkg2.zip is the update package referenced by update_meta2.xml