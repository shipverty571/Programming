import {rightAngle} from "../Resources/ApplicationConstants";

/**
 * Вычисляет новые координаты при повороте вокруг заданного центра.
 * @param selectingCenterX Координата X центра.
 * @param selectingCenterY Координата Y центра.
 * @param x Координата объекта.
 * @param y Координата объекта.
 * @param width Ширина объекта.
 * @param height Высота объекта.
 * @returns {{x: number, y: number}} Возвращает новые координаты объекта.
 */
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