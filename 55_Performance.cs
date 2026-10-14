# /*

```
             CSS PERFORMANCE
```

========================================================

TOPICS COVERED:

1. CSS Performance
2. Reducing CSS File Size
3. Minification
4. Removing Unused CSS
5. Efficient Selectors
6. Avoiding Excessive Nesting
7. CSS Loading
8. Critical CSS
9. External Stylesheets
10. Browser Caching
11. Optimizing Animations
12. Avoiding Layout Shifts

========================================================

1. WHAT IS CSS PERFORMANCE?
   ========================================================

CSS performance refers to writing and delivering CSS in a way
that allows a webpage to load, render and respond efficiently.

Good CSS performance can improve:

```
Page loading speed
Rendering speed
Responsiveness
User experience
Mobile performance
```

Performance is affected by:

```
CSS file size
Number of CSS files
Unused CSS
Complex selectors
Animations
Layout calculations
Resource loading
Caching
```

========================================================
2. REDUCING CSS FILE SIZE
=========================

Smaller CSS files generally require less data to download.

Ways to reduce CSS size:

```
Remove unnecessary rules
Remove unused CSS
Avoid duplicated styles
Use reusable classes
Minify CSS
Remove unnecessary comments in production
Avoid unnecessary frameworks/libraries
Combine CSS where appropriate
```

========================================================
BAD EXAMPLE
===========

*/

/*
.box {
padding: 10px;
}

.box2 {
padding: 10px;
}

.box3 {
padding: 10px;
}
*/

/*
Instead, reuse a common class.

========================================================
BETTER
======

*/

.card {
padding: 10px;
}

/*
HTML can reuse:

```
<div class="card"></div>
<div class="card"></div>
<div class="card"></div>
```

========================================================
3. MINIFICATION
===============

Minification removes unnecessary characters from CSS without
changing its intended behavior.

It can remove:

```
Whitespace
New lines
Comments
Unnecessary formatting
```

========================================================
NORMAL CSS
==========

*/

/*
.button {
background: blue;
color: white;
padding: 10px 20px;
}
*/

# /*

# MINIFIED CSS

.button{background:blue;color:#fff;padding:10px 20px}

========================================================
WHY MINIFY?
===========

Advantages:

```
Smaller file size
Faster download
Lower bandwidth usage
```

IMPORTANT:

Keep readable CSS during development.

Use minified CSS for production builds.

Build tools such as bundlers and preprocessors can automate
this process.

========================================================
4. REMOVING UNUSED CSS
======================

Unused CSS is CSS that is loaded by the browser but is not
actually needed by the current page.

Example:

A website contains:

```
.product-card
.login-box
.dashboard
.admin-panel
.old-banner
.old-menu
```

but a particular page only uses:

```
.product-card
```

The remaining rules may be unnecessary for that page.

========================================================
WHY REMOVE UNUSED CSS?
======================

It can:

```
Reduce CSS file size
Reduce download cost
Simplify maintenance
Improve performance
```

========================================================
WAYS TO REMOVE UNUSED CSS
=========================

```
Delete old CSS manually
Split CSS by page/component
Use build tools
Use framework purge/content detection features
Audit CSS regularly
```

IMPORTANT:

Do not remove dynamically generated classes without checking
how the application works.

========================================================
5. EFFICIENT SELECTORS
======================

Selectors tell the browser which elements a CSS rule applies
to.

Simple selectors are generally easier to maintain and can
reduce unnecessary matching work.

========================================================
SIMPLE SELECTOR
===============

*/

.card {
padding: 20px;
}

# /*

# MORE COMPLEX SELECTOR

*/

.page .content .products .card .title {
font-size: 20px;
}

/*
The second selector has more levels and creates tighter
coupling to the HTML structure.

Prefer meaningful reusable classes where possible.

========================================================
GOOD PRACTICE
=============

*/

.product-title {
font-size: 20px;
}

# /*

# IMPORTANT

Avoid unnecessarily complex selectors.

Prefer:

```
.card-title
```

over deeply dependent selectors such as:

```
.page .main .section ul li div h3
```

========================================================
6. AVOIDING EXCESSIVE NESTING
=============================

Deeply nested CSS can make styles:

```
Hard to understand
Hard to override
Hard to maintain
More tightly coupled to HTML structure
```

========================================================
BAD EXAMPLE
===========

*/

/*
.page .main .content .products .card .body .title {
color: blue;
}
*/

# /*

# BETTER

*/

.product-title {
color: blue;
}

# /*

# NESTING AND PREPROCESSORS

Sass/SCSS makes nesting easy:

```
.card {
    .title {
        color: blue;
    }
}
```

But excessive nesting should still be avoided.

Good CSS architecture usually keeps selectors reasonably
shallow.

========================================================
7. CSS LOADING
==============

CSS must be downloaded before the browser can correctly render
many styles.

A large CSS file can delay the rendering of important content.

Important concepts:

```
External CSS
Critical CSS
Render-blocking resources
Preloading
Caching
Minification
```

========================================================
EXTERNAL CSS
============

HTML:

```
<link rel="stylesheet" href="styles.css">
```

The browser downloads the stylesheet and applies it.

========================================================
8. CRITICAL CSS
===============

Critical CSS is the CSS needed to render the immediately
visible part of a webpage.

This is often called the:

```
Above-the-fold content
```

The idea is:

```
Load important styles early
Delay less-important styles when appropriate
```

========================================================
CONCEPT
=======

Without optimization:

```
HTML
  ↓
Download large CSS
  ↓
Parse CSS
  ↓
Render page
```

With critical CSS:

```
HTML
  ↓
Critical styles
  ↓
Render important content
  ↓
Load remaining styles
```

========================================================
EXAMPLE
=======

*/

body {
margin: 0;
font-family: Arial, sans-serif;
}

header {
background: #111;
color: white;
padding: 20px;
}

/*
These might be considered critical styles if they are needed
to display the initial visible header.

The exact critical CSS depends on the webpage.

========================================================
IMPORTANT
=========

Critical CSS should be generated based on actual page
requirements.

Do not blindly place the entire stylesheet inline.

========================================================
9. EXTERNAL STYLESHEETS
=======================

External stylesheets are CSS files stored separately from HTML.

Example:

```
<link rel="stylesheet" href="style.css">
```

Advantages:

```
Reusable
Easier maintenance
Cleaner HTML
Browser caching
Separation of concerns
```

========================================================
EXAMPLE HTML
============

```
<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="style.css">
</head>

<body>
    <h1>Hello</h1>
</body>
</html>
```

========================================================
WHY EXTERNAL CSS CAN HELP PERFORMANCE
=====================================

The browser can cache the stylesheet.

When another page uses the same stylesheet, the browser may
reuse its cached copy instead of downloading it again.

========================================================
10. BROWSER CACHING
===================

Browser caching stores resources locally so they can be reused
later.

Resources can include:

```
CSS
JavaScript
Images
Fonts
```

========================================================
CSS CACHING
===========

Suppose:

```
page1.html
    ↓
style.css
```

The browser downloads style.css.

Later:

```
page2.html
    ↓
style.css
```

The browser may reuse the cached stylesheet.

This can reduce network requests and loading time.

========================================================
CACHE-CONTROL
=============

Caching is primarily controlled through HTTP response headers.

Example concept:

```
Cache-Control: max-age=31536000
```

This tells the browser/proxy how long the resource may be
considered fresh.

IMPORTANT:

Caching configuration is normally done by the server/CDN,
not by CSS itself.

========================================================
CACHE BUSTING
=============

When CSS changes, browsers may still have an older cached
version.

A common technique is cache busting through versioned
filenames or URLs.

Example:

```
style.v2.css
```

or:

```
style.css?v=2
```

Modern build tools commonly generate hashed filenames such as:

```
style.8f3a21.css
```

========================================================
11. OPTIMIZING ANIMATIONS
=========================

Animations can affect performance, especially when they cause
frequent layout calculations or expensive painting.

Prefer animating properties that are generally more efficient
for visual movement.

Common examples:

```
transform
opacity
```

========================================================
GOOD EXAMPLE
============

*/

.box {
transition: transform 0.3s ease;
}

.box:hover {
transform: translateX(20px);
}

# /*

# OPACITY

*/

.fade {
transition: opacity 0.3s ease;
}

.fade:hover {
opacity: 0.5;
}

# /*

# WHY TRANSFORM?

For many animations, transform and opacity can be handled more
efficiently by modern browsers than properties that require
repeated layout changes.

========================================================
POTENTIALLY EXPENSIVE EXAMPLE
=============================

*/

/*
.box {
transition: width 1s;
}

.box:hover {
width: 500px;
}
*/

/*
Changing width can trigger layout recalculation.

Prefer transform when the visual goal is simply movement.

========================================================
12. AVOIDING LAYOUT SHIFTS
==========================

A layout shift occurs when visible content unexpectedly moves
while the page is loading or changing.

Example:

```
User wants to click a button
          ↓
An image loads above it
          ↓
Button moves down
          ↓
User clicks the wrong element
```

This creates a poor user experience.

========================================================
COMMON CAUSES
=============

```
Images without reserved dimensions
Ads without reserved space
Dynamically inserted content
Web fonts changing text layout
Content loaded above existing content
```

========================================================
13. RESERVE SPACE FOR IMAGES
============================

BAD:

```
<img src="product.jpg" alt="Product">
```

The browser may not initially know the final dimensions.

========================================================
BETTER HTML
===========

```
<img
    src="product.jpg"
    width="800"
    height="600"
    alt="Product"
>
```

========================================================
CSS APPROACH
============

*/

.product-image {
width: 100%;
height: auto;
aspect-ratio: 4 / 3;
object-fit: cover;
}

/*
The browser can use the aspect ratio to reserve appropriate
space before the image fully loads.

========================================================
14. ASPECT-RATIO
================

The aspect-ratio property helps reserve predictable space.

Example:

========================================================
*/

.video-container {
width: 100%;
aspect-ratio: 16 / 9;
background: #ddd;
}

# /*

15. AVOID DYNAMIC CONTENT ABOVE EXISTING CONTENT
    ========================================================

Suppose:

```
Header
Paragraph
Button
```

Then JavaScript inserts a large banner above the paragraph.

The paragraph and button move down.

This creates layout shift.

Better approaches:

```
Reserve space
Load content in predictable areas
Avoid unexpectedly inserting large content above
already-visible content
```

========================================================
16. FONT-RELATED LAYOUT SHIFTS
==============================

Web fonts can sometimes cause text to change size or shape
after the fallback font is replaced.

This may shift surrounding content.

Possible strategies include:

```
Good font loading strategy
Appropriate fallback fonts
font-display choices
Matching fallback font metrics where appropriate
```

========================================================
FONT-DISPLAY
============

Example:

========================================================
*/

@font-face {
font-family: "MyFont";
src: url("myfont.woff2") format("woff2");
font-display: swap;
}

/*
font-display controls how a web font is displayed while the
font is loading.

Common values include:

```
auto
block
swap
fallback
optional
```

========================================================
17. AVOID UNNECESSARY CSS
=========================

Every CSS rule should have a reason to exist.

Avoid:

```
Duplicate rules
Unused classes
Old styles
Unnecessary overrides
Repeated declarations
Excessive !important
```

========================================================
BAD
===

*/

/*
.title {
color: blue;
}

.title {
color: blue;
}

.title {
color: blue;
}
*/

# /*

# BETTER

*/

.title {
color: blue;
}

# /*

18. REUSABLE CSS
    ========================================================

Reusable classes can reduce duplication.

========================================================
*/

.button {
padding: 10px 20px;
border-radius: 6px;
font-weight: bold;
}

.button-primary {
background: blue;
color: white;
}

.button-secondary {
background: gray;
color: white;
}

/*
Both buttons reuse .button.

========================================================
19. CSS VARIABLES FOR REUSE
===========================

*/

:root {
--primary-color: #005fcc;
--spacing: 16px;
--radius: 8px;
}

.card {
padding: var(--spacing);
border-radius: var(--radius);
}

.button {
background: var(--primary-color);
}

/*
CSS variables help avoid repeating the same values and make
design systems easier to maintain.

========================================================
20. AVOID EXCESSIVE !IMPORTANT
==============================

Using too many !important declarations can make CSS difficult
to manage.

BAD:

```
.button {
    color: red !important;
}
```

Use normal cascade and appropriate specificity whenever
possible.

========================================================
21. CSS FILE ORGANIZATION
=========================

Large projects can benefit from organized CSS.

Example:

```
css/
|
|-- reset.css
|-- variables.css
|-- base.css
|-- layout.css
|-- components.css
|-- responsive.css
|
|-- pages/
     |-- home.css
     |-- products.css
```

Good organization can make it easier to:

```
Find styles
Remove unused code
Reuse components
Maintain the project
```

========================================================
22. PRODUCTION CSS PERFORMANCE WORKFLOW
=======================================

DEVELOPMENT:

```
Write readable CSS
      ↓
Organize styles
      ↓
Reuse components
      ↓
Test responsiveness
      ↓
Check accessibility
```

PRODUCTION:

```
Remove unused CSS
      ↓
Minify CSS
      ↓
Compress resources
      ↓
Configure caching
      ↓
Optimize loading
      ↓
Test performance
```

========================================================
23. COMPLETE PERFORMANCE EXAMPLE
================================

*/

:root {
--primary: #005fcc;
}

body {
margin: 0;
font-family: Arial, sans-serif;
}

.container {
width: min(90%, 1200px);
margin: 0 auto;
}

.card {
overflow: hidden;
border-radius: 10px;
transition: transform 0.25s ease;
}

.card-image {
width: 100%;
aspect-ratio: 16 / 9;
object-fit: cover;
display: block;
}

.card:hover {
transform: translateY(-4px);
}

.button {
background: var(--primary);
color: white;
padding: 10px 18px;
border: 0;
border-radius: 6px;
}

# /*

# REDUCED MOTION

*/

@media (prefers-reduced-motion: reduce) {
.card {
transition: none;
}

```
.card:hover {
    transform: none;
}
```

}

# /*

24. PERFORMANCE CHECKLIST
    ========================================================

FILE SIZE:

```
Remove unnecessary CSS
Minify production CSS
Avoid duplication
```

UNUSED CSS:

```
Remove unused rules
Audit old styles
Check dynamic classes before deleting
```

SELECTORS:

```
Keep selectors simple
Avoid excessive specificity
Avoid deep nesting
```

LOADING:

```
Use appropriate external stylesheets
Consider critical CSS
Avoid unnecessarily large CSS files
```

CACHING:

```
Use browser caching
Configure HTTP cache headers
Use versioning/hash filenames
```

ANIMATIONS:

```
Prefer transform and opacity
Avoid unnecessary animations
Respect reduced-motion preferences
```

LAYOUT:

```
Reserve image space
Use width/height or aspect-ratio
Avoid unexpected content insertion
```

========================================================
QUESTIONS AND ANSWERS
=====================

Q1. What is CSS performance?

Answer:

CSS performance refers to optimizing CSS so that webpages
load, render and respond efficiently.

---

Q2. What is minification?

Answer:

Minification removes unnecessary characters such as
whitespace and comments from CSS to reduce file size.

---

Q3. Why should unused CSS be removed?

Answer:

Unused CSS increases file size and may cause unnecessary
download and processing work.

---

Q4. What makes a selector inefficient?

Answer:

Selectors that are unnecessarily complex, deeply nested or
tightly dependent on the HTML structure can make CSS harder
to maintain and may increase selector matching work.

---

Q5. Why should excessive nesting be avoided?

Answer:

Excessive nesting makes CSS harder to read, maintain and
override.

---

Q6. What is Critical CSS?

Answer:

Critical CSS is the CSS required to render the important
initial visible part of a webpage.

---

Q7. What are the advantages of external stylesheets?

Answer:

```
Reusable
Maintainable
Cleaner HTML
Browser caching
Separation of concerns
```

---

Q8. What is browser caching?

Answer:

Browser caching stores previously downloaded resources so
they can potentially be reused on later visits or pages.

---

Q9. Which CSS properties are commonly preferred for efficient
animations?

Answer:

```
transform
opacity
```

---

Q10. What is a layout shift?

Answer:

A layout shift occurs when visible webpage content
unexpectedly moves because of loading or dynamic changes.

---

Q11. How can image-related layout shifts be reduced?

Answer:

Reserve space for images by providing dimensions or using
aspect-ratio.

Example:

```
img {
    width: 100%;
    aspect-ratio: 16 / 9;
}
```

---

Q12. Does CSS control browser caching?

Answer:

Not directly.

Caching is primarily controlled using HTTP response headers
and server/CDN configuration.

========================================================
PRACTICE QUESTIONS
==================

Q1. Write CSS for an image that maintains a fixed aspect ratio.

Solution:

```
img {
    width: 100%;
    aspect-ratio: 16 / 9;
    object-fit: cover;
}
```

---

Q2. Write a reduced-motion media query.

Solution:

```
@media (prefers-reduced-motion: reduce) {
    * {
        animation: none;
        transition: none;
    }
}
```

In production, reduce non-essential motion thoughtfully.

---

Q3. Optimize a button hover animation.

Solution:

```
.button {
    transition: transform 0.2s ease;
}

.button:hover {
    transform: translateY(-2px);
}
```

---

Q4. Give two ways to reduce CSS file size.

Solution:

```
1. Remove unused CSS.
2. Minify CSS.
```

Other methods include removing duplication and avoiding
unnecessary libraries.

---

Q5. Which is better?

A:

```
.page .main .content .card .title
```

B:

```
.card-title
```

Answer:

B is generally better when the class can directly represent
the component or element.

---

Q6. What is cache busting?

Answer:

Cache busting changes the resource URL when its content
changes so that browsers can fetch the new version.

Examples:

```
style.v2.css
```

or a hashed filename generated by a build system.

---

Q7. How can layout shifts be prevented?

Answer:

```
Reserve image dimensions
Use aspect-ratio
Reserve space for dynamic content
Use appropriate font-loading strategies
Avoid inserting content above existing content
```

========================================================
EXAM MEMORY TRICK
=================

FILE SIZE
→ Remove + Minify

UNUSED CSS
→ Delete what is not needed

SELECTORS
→ Keep them simple

NESTING
→ Keep it shallow

LOADING
→ Load only what is necessary

CRITICAL CSS
→ Style visible content first

EXTERNAL CSS
→ Reusable + cacheable

CACHE
→ Reuse downloaded resources

ANIMATION
→ Prefer transform + opacity

LAYOUT SHIFT
→ Reserve space before content loads

========================================================
ONE-LINE REVISION
=================

Reducing CSS File Size
→ Remove unnecessary code and duplication.

Minification
→ Remove unnecessary characters from production CSS.

Removing Unused CSS
→ Delete styles that are not required.

Efficient Selectors
→ Prefer simple, meaningful selectors.

Avoiding Excessive Nesting
→ Keep selectors shallow and maintainable.

CSS Loading
→ Deliver CSS efficiently to reduce rendering delays.

Critical CSS
→ Prioritize styles needed for initial visible content.

External Stylesheets
→ Separate CSS from HTML and enable reuse/caching.

Browser Caching
→ Reuse previously downloaded CSS resources.

Optimizing Animations
→ Prefer transform and opacity for many visual animations.

Avoiding Layout Shifts
→ Reserve space for images and dynamic content.

========================================================
END OF CSS PERFORMANCE
======================

*/
