// IMPORT CORE PACKAGES
import React from 'react';
import { BrowserRouter, Routes, Route } from "react-router-dom";

// IMPORT USER DRFINED COMPONENTS
import {Login} from './components/Account/Login.jsx';

import { 
  ThemeProvider, 
  createTheme 
} from '@mui/material/styles';

// import rtlPlugin from 'stylis-plugin-rtl';
import { CacheProvider } from '@emotion/react';
import createCache from '@emotion/cache';
import { prefixer } from 'stylis';

// Create rtl cache
const cacheRtl = createCache({
  key: 'muirtl',
  stylisPlugins: [prefixer],
});

function RTL(props) {
  return <CacheProvider value={cacheRtl}>{props.children}</CacheProvider>;
}


const theme = createTheme({
  direction: 'rtl',
  typography: {
    fontFamily: ["IRANSansX",'Vazir', 'Arial', 'sans-serif', 'Roboto'].join(','),
    fontSize: 15,
  },
});


const App = () => {
  return (
    <ThemeProvider theme={theme}>
      <RTL>
        <BrowserRouter>
          <Routes>
            <Route path="/" element={<Login />} />
            {/* <Route path="Design" element={<Design />} /> */}
          </Routes>
          
        </BrowserRouter>
        
      </RTL>
    </ThemeProvider>
  );
}

export default App;