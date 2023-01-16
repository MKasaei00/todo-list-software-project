import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button"
import  Grid  from "@mui/material/Grid";
import  TextField  from "@mui/material/TextField";

import { Layout } from "./Layout";
import { height } from "@mui/system";

function Login(){
    return(
        <>
            <Layout>
                <Grid  
                    justifyContent="center" 
                    sx={{
                        width:'100%', height:'98%',
                        mt:0.5, mr:1, p:8, 
                        backgroundColor:'#e0f7fa', 
                        border:1, borderRadius:2, borderColor:'#e0f7fa'
                    }}
                >   
                    <Typography variant="h5" fontWeight='bold' component="div" align="center" >
                         ورود به تسکینو
                    </Typography>
                    <TextField
                        fullWidth
                        id="qualitative_info"
                        label="نام کاربری"
                        sx={{mt:10}}
                        // value={qualitative_info}
                        // onChange={handleQualitative_infoChange}
                    />
                    <TextField
                        fullWidth
                        id="qualitative_info"
                        label="رمز عبور"
                        sx={{mt:2}}
                        type="password"
                        // value={qualitative_info}
                        // onChange={handleQualitative_infoChange}
                    />
                    <Grid container justifyContent="center">
                        <Button
                            type="submit"
                            color='success'
                            variant="contained"
                            sx={{
                                mt:3,
                                mb:5,
                                width:'55%',
                                height:50,
                            }}
                        >ورود</Button>
                        <Typography variant="caption" fontWeight='bold' component="div" align="center" >
                         نام کاربری و رمز عبور ندارید؟
                        </Typography>
                        <Button
                            color='primary'
                            variant="contained"
                            sx={{
                                width:'55%',
                                height:50
                            }}
                        >ثبت نام</Button>
                    </Grid>
                </Grid>    
            </Layout>
            
        </>
    );
}

export{
    Login,
};