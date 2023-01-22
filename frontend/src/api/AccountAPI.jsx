import { LOGIN_URL } from "../constants/routes";
import { SIGNUP_URL } from "../constants/routes";

/////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////    Login API     /////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////


const login = async (data,navigate,setSnackbarInfo) => {
    const response= await fetch(LOGIN_URL, { method: 'POST',
    // credentials: 'include',
    headers: {
        "Content-Type": "application/json",
      }, body: JSON.stringify(data) });
    console.log('status code: ', response.status);
    if (response.status!==200) {
      setSnackbarInfo({
        open: true,
        message: 'رمز عبور یا نام کاربری وارد شده اشتباه است',
        severity: 'error',
      });
      return;
    }else{
      // const responseJson = await response.json();
      // console.log(responseJson);
      // localStorage.setItem('key',responseJson.key);
      setSnackbarInfo({
        open: true, 
        message: 'با موفقیت لاگین شدید',
        severity: 'success',
      });
    //   navigate('/Design');
    }
};

/////////////////////////////////////////////////////////////////////////////////////////
//////////////////////////////////    Signup API     /////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////////////


const signup = async (data,navigate,setSnackbarInfo) => {
  const response= await fetch(SIGNUP_URL, { method: 'POST',
  // credentials: 'include',
  headers: {
      "Content-Type": "application/json",
    }, body: JSON.stringify(data) });
  console.log('status code: ', response.status);
  if (response.status!==200) {
    setSnackbarInfo({
      open: true,
      message: 'اشتباهی پیش آمده. دوباره تلاش کنید.',
      severity: 'error',
    });
    return;
  }else{
    // const responseJson = await response.json();
    // console.log(responseJson);
    // localStorage.setItem('key',responseJson.key);
    setSnackbarInfo({
      open: true, 
      message: 'با موفقیت ثبت نام شدید',
      severity: 'success',
    });
    navigate('/Login');
  }
};


export {
    login,
    signup,
}