<template>
  <header class="header">
    <a class="header__logo" href="#">
      <img src="@/assets/logo.svg">
    </a>
  </header>
  <div class="continer">
    <router-view/>
  </div>
  <footer class="footer">
``
  </footer>
</template>

<style>
*,
*::before,
*::after{
  box-sizing: border-box;

}
.home{
  display: flex;
  width: 100%;
}
.continer {
  max-width: 1250px;
  width: 100%;
  margin: 0 auto;
}
#app {
  position: absolute;

  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: space-between;
  top: 0;
  bottom: 0;
  left: 0;
  height: 100vh;
  min-width: 100%;
}
.footer{
  width: 100%;
  height: 50px;
  background: #000;
  margin-top: 30px;
}
.header{
  background-image: linear-gradient(90deg,#320ce6,#4954f0 5.23%,#2584d7 13.75%,#314993 24.69%,#304ce1 38.26%,#5a39b5 57.41%,#2e59ac 67.13%,#639fec 79.01%,#82a2ee 91.92%,#1ae2e9);
  position:sticky;
  top: 0;
  -webkit-box-pack: justify;
      -ms-flex-pack: justify;
          justify-content: space-between;
  -webkit-box-align: center;
      -ms-flex-align: center;
          align-items: center;
  width: 100%;
  height: 100px;
  max-height: 100px;
  margin-bottom: 50px;
  padding: 0 120px;
  z-index: 5;
}
.header__logo{
  width: 100%;
}
 html {
  line-height: 1.15; /* 1 */
  -webkit-text-size-adjust: 100%; /* 2 */
}


body {
  margin: 0;
}


main {
  display: block;
}


h1 {
  font-size: 2em;
  margin: 0.67em 0;
}

hr {
  box-sizing: content-box; /* 1 */
  height: 0; /* 1 */
  overflow: visible; /* 2 */
}

pre {
  font-family: monospace, monospace; /* 1 */
  font-size: 1em; /* 2 */
}

a {
  background-color: transparent;
}


abbr[title] {
  border-bottom: none; /* 1 */
  text-decoration: underline; /* 2 */
  text-decoration: underline dotted; /* 2 */
}

b,
strong {
  font-weight: bolder;
}

code,
kbd,
samp {
  font-family: monospace, monospace; /* 1 */
  font-size: 1em; /* 2 */
}
small {
  font-size: 80%;
}
sub,
sup {
  font-size: 75%;
  line-height: 0;
  position: relative;
  vertical-align: baseline;
}

sub {
  bottom: -0.25em;
}

sup {
  top: -0.5em;
}

img {
  border-style: none;
}

button,
input,
optgroup,
select,
textarea {
  font-family: inherit; /* 1 */
  font-size: 100%; /* 1 */
  line-height: 1.15; /* 1 */
  margin: 0; /* 2 */
}

button,
input { /* 1 */
  overflow: visible;
}

button,
select { /* 1 */
  text-transform: none;
}

button,
[type="button"],
[type="reset"],
[type="submit"] {
  -webkit-appearance: button;
}

button::-moz-focus-inner,
[type="button"]::-moz-focus-inner,
[type="reset"]::-moz-focus-inner,
[type="submit"]::-moz-focus-inner {
  border-style: none;
  padding: 0;
}

button:-moz-focusring,
[type="button"]:-moz-focusring,
[type="reset"]:-moz-focusring,
[type="submit"]:-moz-focusring {
  outline: 1px dotted ButtonText;
}

fieldset {
  padding: 0.35em 0.75em 0.625em;
}

legend {
  box-sizing: border-box; /* 1 */
  color: inherit; /* 2 */
  display: table; /* 1 */
  max-width: 100%; /* 1 */
  padding: 0; /* 3 */
  white-space: normal; /* 1 */
}


progress {
  vertical-align: baseline;
}


textarea {
  overflow: auto;
}


[type="checkbox"],
[type="radio"] {
  box-sizing: border-box; /* 1 */
  padding: 0; /* 2 */
}
[type="number"]::-webkit-inner-spin-button,
[type="number"]::-webkit-outer-spin-button {
  height: auto;
}
[type="search"] {
  -webkit-appearance: textfield; /* 1 */
  outline-offset: -2px; /* 2 */
}
[type="search"]::-webkit-search-decoration {
  -webkit-appearance: none;
}
::-webkit-file-upload-button {
  -webkit-appearance: button; /* 1 */
  font: inherit; /* 2 */
}
details {
  display: block;
}
summary {
  display: list-item;
}
template {
  display: none;
}

[hidden] {
  display: none;
}
@media (max-width:990px){
  .home{
    flex-direction: column;
  }
  .continer{
    max-width:700px
  }
}
@media(max-width:490px){
  #app{
    height:fit-content;
  }
}
@media (max-width:416px) {
  .header{
    padding: 0;
    margin-bottom: 100px;
  }
  .continer{
    max-width: 300px;
  }
  
}
</style>
