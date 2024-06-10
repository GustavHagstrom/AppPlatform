window.resizeListener = {
    callbacks: [],
    breakpoints: [600, 960, 1280, 1920, 2560], // Define your breakpoints here
    XXL: 2560,

    onResize: function () {
        let width = window.innerWidth;
        if (width >= window.resizeListener.XXL)
        {
            window.resizeListener.notifyCallbacks(window.resizeListener.XXL);
        }
        else
        {
            for (let i = 0; i < window.resizeListener.breakpoints.length; i++)
            {
                if (width <= window.resizeListener.breakpoints[i])
                {
                    window.resizeListener.notifyCallbacks(window.resizeListener.breakpoints[i]);
                    break;
                }
            }
        }
    },

    notifyCallbacks: function (breakpoint) {
        window.resizeListener.callbacks.forEach(callback => {
            callback.invokeMethodAsync('OnBreakpointChange', breakpoint);
        });
    },

    addCallback: function (dotNetObjectRef) {
        window.resizeListener.callbacks.push(dotNetObjectRef);
        dotNetObjectRef.invokeMethodAsync('OnBreakpointChange', window.innerWidth);
    },

    removeCallback: function (dotNetObjectRef) {
        window.resizeListener.callbacks = window.resizeListener.callbacks.filter(callback => callback !== dotNetObjectRef);
    }
};

window.addEventListener('resize', window.resizeListener.onResize);