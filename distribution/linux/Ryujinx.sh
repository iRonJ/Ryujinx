#!/bin/sh

SCRIPT_DIR=$(dirname "$(realpath "$0")")
<<<<<<< HEAD

if [ -f "$SCRIPT_DIR/Ryujinx.Headless.SDL2" ]; then
    RYUJINX_BIN="Ryujinx.Headless.SDL2"
fi
=======
RYUJINX_BIN="Ryujinx"
>>>>>>> 1ec71635b (sync with main branch)

if [ -f "$SCRIPT_DIR/Ryujinx.Ava" ]; then
    RYUJINX_BIN="Ryujinx.Ava"
fi

<<<<<<< HEAD
if [ -f "$SCRIPT_DIR/Ryujinx" ]; then
    RYUJINX_BIN="Ryujinx"
fi

if [ -z "$RYUJINX_BIN" ]; then
    exit 1
fi

COMMAND="env DOTNET_EnableAlternateStackCheck=1"

if command -v gamemoderun > /dev/null 2>&1; then
    COMMAND="$COMMAND gamemoderun"
fi

exec $COMMAND "$SCRIPT_DIR/$RYUJINX_BIN" "$@"
=======
if [ -f "$SCRIPT_DIR/Ryujinx.Headless.SDL2" ]; then
    RYUJINX_BIN="Ryujinx.Headless.SDL2"
fi

env DOTNET_EnableAlternateStackCheck=1 "$SCRIPT_DIR/$RYUJINX_BIN" "$@"
>>>>>>> 1ec71635b (sync with main branch)
