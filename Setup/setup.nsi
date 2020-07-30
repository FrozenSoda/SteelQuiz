;SteelQuiz Setup Script
;NSIS Modern User Interface
;Based on Basic Example Script by Joost Verburg

;--------------------------------
  ;Include Modern UI
  !include "MUI2.nsh"

;--------------------------------

;Add version info
!define PRODUCT_VERSION "5.0.1.0"

VIProductVersion "${PRODUCT_VERSION}"
VIFileVersion "${PRODUCT_VERSION}"
VIAddVersionKey "FileVersion" "${PRODUCT_VERSION}"
VIAddVersionKey "LegalCopyright" "(C) 2019 Steel9Apps"
VIAddVersionKey "FileDescription" "A quiz program designed to make learning words easier"

;General

  ;Name and file
  Name "SteelQuiz"
  OutFile "SteelQuizSetup.exe"

  ;Default installation folder
  InstallDir "$LOCALAPPDATA\SteelQuiz"
  
  ;Get installation folder from registry if available
  InstallDirRegKey HKCU "Software\SteelQuiz" ""

  ;Request application privileges for Windows Vista
  RequestExecutionLevel user

;--------------------------------
;Interface Settings

  !define MUI_ABORTWARNING

;--------------------------------
;Pages

  !insertmacro MUI_PAGE_LICENSE "..\LICENSE"
  !insertmacro MUI_PAGE_LICENSE "..\LICENSE_3RD_PARTY"
  !insertmacro MUI_PAGE_COMPONENTS
  !insertmacro MUI_PAGE_DIRECTORY
  !insertmacro MUI_PAGE_INSTFILES
  
  !insertmacro MUI_UNPAGE_CONFIRM
  !insertmacro MUI_UNPAGE_INSTFILES
  
;--------------------------------
;Languages
 
  !insertmacro MUI_LANGUAGE "English"

;--------------------------------

  !define SHCNE_ASSOCCHANGED 0x08000000
  !define SHCNF_IDLIST 0
 
!macro REFRESH_SHELL_ICONS_MACRO un
	Function ${un}RefreshShellIcons
	  ; By jerome tremblay - april 2003
	  System::Call 'shell32.dll::SHChangeNotify(i, i, i, i) v \
	  (${SHCNE_ASSOCCHANGED}, ${SHCNF_IDLIST}, 0, 0)'
	FunctionEnd
!macroend

!insertmacro REFRESH_SHELL_ICONS_MACRO ""
!insertmacro REFRESH_SHELL_ICONS_MACRO "un."

;Installer Sections

Section "SteelQuiz" SecSteelQuiz

  ;Required
  SectionIn RO 
  
  SetOutPath "$INSTDIR"
  
  ;Files
  File "..\SteelQuiz\bin\Release\SteelQuiz.exe"
  File "..\SteelQuiz\bin\Release\Newtonsoft.Json.dll"
  File "..\SteelQuiz\bin\Release\AutoUpdater.NET.dll"
  File "..\SteelQuiz\bin\Release\Fastenshtein.dll"
  
  ; Extract InstallInfo.json, for example to prevent SteelQuiz from asking user to accept license again, to ensure SteelQuiz knowns that it's installed and not portable, and to prevent SteelQuiz from re-registering file associations
  File "InstallInfo.json"
  
  ;Store installation folder
  WriteRegStr HKCU "Software\SteelQuiz" "" $INSTDIR
  
  ;Write the uninstall keys for Windows
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "DisplayName" "SteelQuiz"
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "UninstallString" '"$INSTDIR\uninstall.exe"'
  WriteRegStr HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "Publisher" "Steel9Apps"
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "NoModify" 1
  WriteRegDWORD HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz" "NoRepair" 1
  
  ;Create uninstaller
  WriteUninstaller "$INSTDIR\Uninstall.exe"

SectionEnd

Section "Register File Associations" SecRegisterFileAssociations
  WriteRegStr HKCU "Software\Classes\.steelquiz" "" "SteelQuiz_Quiz_File"
  WriteRegStr HKCU "Software\Classes\SteelQuiz_Quiz_File" "" "SteelQuiz Quiz"
  WriteRegStr HKCU "Software\Classes\SteelQuiz_Quiz_File\DefaultIcon" "" "$INSTDIR\SteelQuiz.exe"
  WriteRegStr HKCU "Software\Classes\SteelQuiz_Quiz_File\shell\open\command" "" '"$INSTDIR\SteelQuiz.exe" "%1"'
  
  Call RefreshShellIcons
SectionEnd

Section "Start Menu Shortcuts" SecStartMenuShortcuts
  ;Create start menu shortcuts
  CreateDirectory "$SMPROGRAMS\SteelQuiz"
  CreateShortcut "$SMPROGRAMS\SteelQuiz\SteelQuiz.lnk" "$INSTDIR\SteelQuiz.exe" "" "$INSTDIR\SteelQuiz.exe" 0
  CreateShortcut "$SMPROGRAMS\SteelQuiz\Uninstall SteelQuiz.lnk" "$INSTDIR\uninstall.exe" "" "$INSTDIR\uninstall.exe" 0
  
SectionEnd

Section "Desktop Shortcut" SecDesktopShortcut
   CreateShortcut "$DESKTOP\SteelQuiz.lnk" "$INSTDIR\SteelQuiz.exe" "" "$INSTDIR\SteelQuiz.exe" 0
SectionEnd

;--------------------------------
;Descriptions

  ;Language strings
  LangString DESC_SecSteelQuiz ${LANG_ENGLISH} "SteelQuiz (required)"
  LangString DESC_SecStartMenuShortcuts ${LANG_ENGLISH} "Start Menu Shortcuts"
  LangString DESC_SecDesktopShortcut ${LANG_ENGLISH} "Desktop Shortcut"
  LangString DESC_SecRegisterFileAssociations ${LANG_ENGLISH} "Register File Associations (recommended)$\r$\n$\r$\nIf you register file associations, you can open quizzes just by double clicking their files!"

  ;Assign language strings to sections
  !insertmacro MUI_FUNCTION_DESCRIPTION_BEGIN
    !insertmacro MUI_DESCRIPTION_TEXT ${SecSteelQuiz} $(DESC_SecSteelQuiz)
    !insertmacro MUI_DESCRIPTION_TEXT ${SecStartMenuShortcuts} $(DESC_SecStartMenuShortcuts)
	!insertmacro MUI_DESCRIPTION_TEXT ${SecDesktopShortcut} $(DESC_SecDesktopShortcut)
	!insertmacro MUI_DESCRIPTION_TEXT ${SecRegisterFileAssociations} $(DESC_SecRegisterFileAssociations)
  !insertmacro MUI_FUNCTION_DESCRIPTION_END

;--------------------------------
;Uninstaller Section

Section "Uninstall"
  ;Delete app shortcuts
  Delete "$DESKTOP\SteelQuiz.lnk"
  Delete "$SMPROGRAMS\SteelQuiz\SteelQuiz.lnk"
  
  ;Unregister file associations
  DeleteRegKey HKCU "Software\Classes\.steelquiz"
  DeleteRegKey HKCU "Software\Classes\SteelQuiz_Quiz_File"
  
  Call un.RefreshShellIcons
  
  ;Delete files
  Delete "$INSTDIR\SteelQuiz.exe"
  Delete "$INSTDIR\Newtonsoft.Json.dll"
  Delete "$INSTDIR\AutoUpdater.NET.dll"
  Delete "$INSTDIR\Fastenshtein.dll"
  Delete "$INSTDIR\uninstall.exe"
  Delete "$INSTDIR\ACCEPTED_LICENSE"
  Delete "$INSTDIR\InstallInfo.json"

  ;Delete remaining shortcuts
  Delete "$SMPROGRAMS\SteelQuiz\Uninstall SteelQuiz.lnk"
  Delete "$SMPROGRAMS\SteelQuiz\*.*"
  RMDir "$SMPROGRAMS\SteelQuiz"
  
  ;Delete install directory
  RMDir "$INSTDIR"

  ;Delete registry keys
  DeleteRegKey HKCU "Software\SteelQuiz\Communication"
  DeleteRegKey /ifempty HKCU "Software\SteelQuiz"
  DeleteRegKey HKCU "Software\Microsoft\Windows\CurrentVersion\Uninstall\SteelQuiz"

SectionEnd
