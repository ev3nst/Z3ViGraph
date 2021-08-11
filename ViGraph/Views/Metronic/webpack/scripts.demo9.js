// Keenthemes' plugins
window.KTUtil = require('@/src/js/components/util.js');
window.KTApp = require('@/src/js/components/app.js');
window.KTCard = require('@/src/js/components/card.js');
window.KTCookie = require('@/src/js/components/cookie.js');
window.KTDialog = require('@/src/js/components/dialog.js');
window.KTHeader = require('@/src/js/components/header.js');
window.KTImageInput = require('@/src/js/components/image-input.js');
window.KTMenu = require('@/src/js/components/menu.js');
window.KTOffcanvas = require('@/src/js/components/offcanvas.js');
window.KTScrolltop = require('@/src/js/components/scrolltop.js');
window.KTToggle = require('@/src/js/components/toggle.js');
window.KTWizard = require('@/src/js/components/wizard.js');
require('@/src/js/components/datatable/core.datatable.js');
require('@/src/js/components/datatable/datatable.checkbox.js');

// Metronic layout base js
window.KTLayoutAside = require('@/src/js/layout/base/aside.js');
window.KTLayoutAsideMenu = require('@/src/js/layout/base/aside-menu.js');
window.KTLayoutContent = require('@/src/js/layout/base/content.js');
window.KTLayoutFooter = require('@/src/js/layout/base/footer.js');
window.KTLayoutHeader = require('@/src/js/layout/base/header.js');
window.KTLayoutHeaderMenu = require('@/src/js/layout/base/header-menu.js');
window.KTLayoutHeaderTopbar = require('@/src/js/layout/base/header-topbar.js');
window.KTLayoutStickyCard = require('@/src/js/layout/base/sticky-card.js');
window.KTLayoutStretchedCard = require('@/src/js/layout/base/stretched-card.js');
window.KTLayoutSubheader = require('@/src/js/layout/base/subheader.js');

// Metronic layout extended js
window.KTLayoutSearch = window.KTLayoutSearchOffcanvas = KTLayoutSearchInline = require('@/src/js/layout/extended/search.js');

require('@/src/js/layout/initialize.js');
