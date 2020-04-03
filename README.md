# SteelQuiz
## A quiz program designed to make learning easier  

Tired of practising vocabulary/sets of questions in the traditional way, or with software/websites that ask the same questions over and over? Then you should take a look at SteelQuiz. SteelQuiz contains a feature which selects the questions to ask based on what you know. Questions you have already learned won't be asked for as much as those you are a bit more unsure about.

**[![button](Res/Web/download_setup.png)](https://github.com/steel9/SteelQuiz/releases/latest/download/SteelQuizSetup.exe)**
**[![button](Res/Web/download_portable.png)](https://github.com/steel9/SteelQuiz/releases/latest/download/SteelQuizPortable.zip)**   
&NewLine;   
&NewLine;   
### Intelligent Learning
SteelQuiz contains a feature called _**Intelligent Learning**_, which speeds up the learning process. Words you already know won't be asked as much as words you are unsure about. **This system activates after two rounds**, as it needs to gather some information first, before it can begin sorting out words. To disable Intelligent Learning, just click on the disable button while practising the quiz.
It is always recommended to do a full test of the quiz after learning everything with Intelligent Learning, as you might have forgotten some words. Intelligent Learning also uses randomness, to occasionally ask questions you are sure of, to make sure you don't forget them.

### Quiz Editor
You can create and edit quizzes, with the built in quiz editor. It has full support for undo/redo, provides support for adding synonyms to words, and automatically creates recovery saves for your project in case SteelQuiz exits unexpectedly before you save.

### Automatic updates
SteelQuiz automatically downloads and installs updates, offers to download them, or neither, depending on your preferences. It is recommended to always install all available updates, as they often contain important bug fixes and improvements.    
&NewLine;   
&NewLine;   
&NewLine;   
### Additional notes
- The portable version (and the installed version) saves user data (config, quizzes, quiz progress etc.) in '%appdata%\SteelQuiz'.
- The uninstaller does not remove user data.
&NewLine;   
&NewLine;   
&NewLine;   
### System requirements
- **Operating system:** Windows 7 SP1 or later
- **Runtime:** Microsoft .NET Framework 4.7.2
   
SteelQuiz should be able to run on Mac and Linux, in CrossOver/Wine, but nothing is guaranteed.
SteelQuiz has been tested in CrossOver on Ubuntu 18.04.2 LTS, and worked acceptably, but as said before, nothing is guaranteed to work.
**Make sure you install .NET Framework in CrossOver/Wine before installing SteelQuiz!**

### Incompatible software
- **f.lux Microsoft Store version**   
Causes problems with installation, updates, and uninstallation of SteelQuiz. The specific cause of the problem is currently unknown. For some reason, it causes System PID 4 to lock SteelQuiz.exe.   
**Solution:** Uninstall the f.lux Microsoft Store version, and install the non-Store version of f.lux instead (the one you download from their website).

## Contributing
Thank you for your interest in contributing to SteelQuiz! If you do so, please follow the [coding conventions](CODING_CONVENTIONS.md).   

### Development tools
- Microsoft Visual Studio Community 2019
- Nullsoft Scriptable Install System v3
- Git v2

## Contact
**E-mail:** steel9apps [at] gmail.com
