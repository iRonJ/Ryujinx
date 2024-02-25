#!/bin/bash

set -e

INSTALL_DIRECTORY=$1
NEW_APP_DIRECTORY=$2
APP_PID=$3
<<<<<<< HEAD
APP_ARGUMENTS=("${@:4}")
=======
APP_ARGUMENTS="${@:4}"
>>>>>>> 1ec71635b (sync with main branch)

error_handler() {
    local lineno="$1"

    script="""
    set alertTitle to \"Ryujinx - Updater error\"
    set alertMessage to \"An error occurred during Ryujinx update (updater.sh:$lineno)\n\nPlease download the update manually from our website if the problem persists.\"
    display dialog alertMessage with icon caution with title alertTitle buttons {\"Open Download Page\", \"Exit\"}
    set the button_pressed to the button returned of the result

    if the button_pressed is \"Open Download Page\" then
        open location \"https://ryujinx.org/download\"
    end if
    """

    osascript -e "$script"
    exit 1
}

<<<<<<< HEAD
trap 'error_handler ${LINENO}' ERR

# Wait for Ryujinx to exit.
# If the main process is still acitve, we wait for 1 second and check it again.
# After the fifth time checking, this script exits with status 1.

attempt=0
while true; do
    if lsof -p "$APP_PID" +r 1 &>/dev/null || ps -p "$APP_PID" &>/dev/null; then
        if [ "$attempt" -eq 4 ]; then
            exit 1
        fi
        sleep 1
    else
        break
    fi
    (( attempt++ ))
done

sleep 1

=======
# Wait for Ryujinx to exit
# NOTE: in case no fds are open, lsof could be returning with a process still living.
# We wait 1s and assume the process stopped after that
lsof -p $APP_PID +r 1 &>/dev/null
sleep 1

trap 'error_handler ${LINENO}' ERR

>>>>>>> 1ec71635b (sync with main branch)
# Now replace and reopen.
rm -rf "$INSTALL_DIRECTORY"
mv "$NEW_APP_DIRECTORY" "$INSTALL_DIRECTORY"

if [ "$#" -le 3 ]; then
    open -a "$INSTALL_DIRECTORY"
else
<<<<<<< HEAD
    open -a "$INSTALL_DIRECTORY" --args "${APP_ARGUMENTS[@]}"
fi
=======
    open -a "$INSTALL_DIRECTORY" --args "$APP_ARGUMENTS"
fi
>>>>>>> 1ec71635b (sync with main branch)
