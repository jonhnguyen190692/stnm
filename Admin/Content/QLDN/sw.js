importScripts('js/sw-toolbox.js');


toolbox.options.debug = false;

// toolbox.precache(['/']);

// toolbox.router.get('/', toolbox.networkFirst);

// The route for the images
toolbox.router.get('/js/(.*)', toolbox.cacheFirst, {cache: {name: 'js', maxEntries: 5, maxAgeSeconds: 8640000}});
toolbox.router.get('/css/(.*)', toolbox.cacheFirst, {cache: {name: 'css', maxEntries: 5, maxAgeSeconds: 8640000}});
toolbox.router.get('/imgs/(.*)', toolbox.cacheFirst, {cache: {name: 'imgs', maxEntries: 50, maxAgeSeconds: 8640000}});

//for api domain
var apiorigin = /api\.teamcrop\.com/;
if (typeof location != 'undefined' && location.hasOwnProperty('origin') && location.origin.indexOf('beta') >= 0) {
    apiorigin = /api\.teamcrop\.com/;
}


toolbox.router.get(/.*fulldata.*/, toolbox.cacheFirst, {cache: {name: 'fulldata', maxEntries: 30, maxAgeSeconds: 8640000}, origin: apiorigin});
toolbox.router.get(/.*photoavatar.*/, toolbox.cacheFirst, {cache: {name: 'photoavatar', maxEntries: 200, maxAgeSeconds: 8640000}, origin: apiorigin});
