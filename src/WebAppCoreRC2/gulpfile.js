/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var webroot = "./wwwroot/";

var paths = {
    js: webroot + "js/**/*.js",
    minJs: webroot + "js/**/*.min.js",
    css: webroot + "css/**/*.css",
    minCss: webroot + "css/**/*.min.css",
    concatJsDest: webroot + "js/site.min.js",
    concatCssDest: webroot + "css/site.min.css"
};



gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean", ["clean:js", "clean:css"]);

gulp.task("min:js", function () {
    return gulp.src([paths.js, "!" + paths.minJs], { base: "." })
        .pipe(concat(paths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("min:css", function () {
    return gulp.src([paths.css, "!" + paths.minCss])
        .pipe(concat(paths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

var myPaths = {
    js: [
        webroot + "lib/jquery/**/*.js",
        webroot + "lib/jquery-validation/dist/jquery.validate.js",
        webroot + "lib/jquery-validation/dist/additional-methods.js",
        webroot + "lib/jquery-validation-unobtrusive/*.js",
        webroot + "lib/bootstrap/**/*.js",
        webroot + "lib/icheck/*.js"
    ],
    css: [
        webroot + "lib/bootstrap/**/*.css",
        webroot + "css/site.css"
    ],
    concatJsDest: webroot + "js/app.min.js",
    concatCssDest: webroot + "css/app.min.css"
}

gulp.task("myMinJs", function () {
    return gulp.src(myPaths.js, { base: "." })
        .pipe(concat(myPaths.concatJsDest))
        .pipe(uglify())
        .pipe(gulp.dest("."));
});

gulp.task("myMinCss", function () {
    return gulp.src(myPaths.css)
        .pipe(concat(myPaths.concatCssDest))
        .pipe(cssmin())
        .pipe(gulp.dest("."));
});

gulp.task('myFonts', function () {
    return gulp.src(
        [
            webroot + 'lib/bootstrap/dist/fonts/*.*'
        ])
        .pipe(gulp.dest(webroot + 'fonts/'));
});

gulp.task("min", ["min:js", "min:css"]);

gulp.task("default", ['myFonts','myMinJs','myMinCss']);
