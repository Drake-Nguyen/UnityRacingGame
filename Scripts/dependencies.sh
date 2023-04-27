#!/bin/bash

UNITY_PROJECT_PATH="/path/to/unity/project/Assets"
DEPENDENCIES=("texture" "Spa Francorchamps" "3d objects")
UNITY_LOG_FILE="unity_log.txt"

if ! which unity >/dev/null; then
  echo "Unity is not installed. Please install Unity and try again."
  exit 1
fi

if ! test -d "$UNITY_PROJECT_PATH"; then
  echo "Unity project directory not found: $UNITY_PROJECT_PATH"
  exit 1
fi

for dep in "${DEPENDENCIES[@]}"; do
  if ! which "$dep" >/dev/null; then
    echo "Dependency not found: $dep"
    exit 1
  fi
done

unity -batchmode -nographics -logFile "$UNITY_LOG_FILE" -projectPath "$UNITY_PROJECT_PATH" -quit

if grep -q "Error" "$UNITY_LOG_FILE"; then
  echo "Unity project contains errors. Please check the log file: $UNITY_LOG_FILE"
  exit 1
fi

if grep -q "Warning" "$UNITY_LOG_FILE"; then
  echo "Unity project contains warnings. Please check the log file: $UNITY_LOG_FILE"
fi

rm -f "$UNITY_LOG_FILE"
