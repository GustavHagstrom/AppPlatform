function animateHeight(element, newHeight)
{
    let currentHeight = element.offsetHeight;
    let difference = newHeight - currentHeight;
    let duration = 300; // in milliseconds
    let perTick = difference / duration * 10;

    let interval = setInterval(() =>
    {
        currentHeight += perTick;
        element.style.height = currentHeight + "px";

        if (currentHeight >= newHeight)
        {
            clearInterval(interval);
        }
    }, 10);
}