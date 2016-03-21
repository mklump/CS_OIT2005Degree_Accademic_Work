@echo off
:next
if "%1" == "" goto end
  echo %1
  shift /1
  goto next
:end