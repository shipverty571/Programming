import {rightAngle} from "../Resources/ApplicationConstants";

function MultiRotate(selectingCenterX, selectingCenterY, x, y, width, height) {
    let centerX = x + width / 2;
    let centerY = (y + height / 2);
    let radians = rightAngle * Math.PI / 180;
    let newX =
        (selectingCenterX - centerX) * Math.cos(radians) +
        (selectingCenterY - centerY) * Math.sin(radians) +
        selectingCenterX;
    let newY =
        (-1) *
        (selectingCenterX - centerX) * Math.sin(radians) +
        (selectingCenterY - centerY) * Math.cos(radians) +
        selectingCenterY;
    newX = newX - width / 2;
    newY = newY - height / 2;
    return {
        x: newX, y: newY
    }
}

export default MultiRotate;