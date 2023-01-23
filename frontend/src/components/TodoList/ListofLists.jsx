
import Button from '@mui/material/Button';
import Card from '@mui/material/Card';
import CardActions from '@mui/material/CardActions';
import CardContent from '@mui/material/CardContent';
import DeleteIcon from '@mui/icons-material/Delete';
import Divider from '@mui/material/Divider';
import Fab from '@mui/material/Fab';
import Grid from '@mui/material/Grid';
import OpenInFullIcon from '@mui/icons-material/OpenInFull';
import Tooltip from '@mui/material/Tooltip';
import Typography from '@mui/material/Typography';

import { Layout } from "./Layout";

function ListofLists(props){
    return(
        <Layout>
            <Grid container alignItems='flex-start' justifyContent='space-between' sx={{overflow:'auto', height:"100%", p:2}}>
                <Grid sx={{width:'48%', height:'100%'}}>
                    <Grid item xs={12} md={12} sx={{textAlign:'center',backgroundColor: '#3b70a4', height:50 ,p:1,mb:3 ,fontWeight:'bold', fontSize:'20px',color:'white'}} >
                    لیست‌های شخصی
                    </Grid>
                    <Grid container spacing={1} justifyContent="center">
                        <Grid item >
                            <Card  sx={{ height: 160,width: 250}}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                    کار‌های شخصی
                                    </Typography>
                                    <Typography variant="body2">
                                    این لیست برای فعالیت‌های شخصی طراحی شده است.
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Tooltip title="Open">
                                        <Fab color="success" size="small" style={{ transform: 'scale(0.7)',}} aria-label="open" >
                                        <OpenInFullIcon  />
                                        </Fab>
                                    </Tooltip>
                                    <Tooltip title="Delete">
                                        <Fab color="error" size="small" style={{ transform: 'scale(0.7)' , }} aria-label="checklist">
                                        <DeleteIcon  />
                                        </Fab>
                                    </Tooltip>
                                </CardActions>
                            </Card>
                        </Grid>
                        <Grid item  >
                            <Card  sx={{ height: 160,width: 250}}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                    کار‌های دانشگاه
                                    </Typography>
                                    <Typography variant="body2">
                                    این لیست برای فعالیت‌های دانشگاه طراحی شده است.
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Tooltip title="Open">
                                        <Fab color="success" size="small" style={{ transform: 'scale(0.7)',}} aria-label="open" >
                                        <OpenInFullIcon  />
                                        </Fab>
                                    </Tooltip>
                                    <Tooltip title="Delete">
                                        <Fab color="error" size="small" style={{ transform: 'scale(0.7)' , }} aria-label="checklist">
                                        <DeleteIcon  />
                                        </Fab>
                                    </Tooltip>
                                </CardActions>
                            </Card>
                        </Grid>
                        <Grid item  >
                            <Card  sx={{ height: 160,width: 250}}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                    اوقات فراغت
                                    </Typography>
                                    <Typography variant="body2">
                                    این لیست برای فعالیت‌های اوقات فراغت طراحی شده است.
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Tooltip title="Open">
                                        <Fab color="success" size="small" style={{ transform: 'scale(0.7)',}} aria-label="open" >
                                        <OpenInFullIcon  />
                                        </Fab>
                                    </Tooltip>
                                    <Tooltip title="Delete">
                                        <Fab color="error" size="small" style={{ transform: 'scale(0.7)' , }} aria-label="checklist">
                                        <DeleteIcon  />
                                        </Fab>
                                    </Tooltip>
                                </CardActions>
                            </Card>
                        </Grid>
                    </Grid>
                    
                </Grid>
                
                <Divider orientation="vertical"></Divider>
                <Grid sx={{width:'48%', height:'100%'}}>
                    <Grid item xs={12} md={12} sx={{width:'100%',textAlign:'center',backgroundColor: '#3b70a4', height:50 ,p:1,mb:3  ,fontWeight:'bold', fontSize:'20px',color:'white'}} >
                    لیست‌های اشتراکی
                    </Grid>
                    <Grid container spacing={1} justifyContent="center">
                        <Grid item >
                            <Card  sx={{ height: 160,width: 250}}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                    پروژه نرم‌افزار
                                    </Typography>
                                    <Typography variant="body2">
                                    این لیست برای پروژه درس مهندسی نرم‌افزار طراحی شده است.
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Tooltip title="Open">
                                        <Fab color="success" size="small" style={{ transform: 'scale(0.7)',}} aria-label="open" >
                                        <OpenInFullIcon  />
                                        </Fab>
                                    </Tooltip>
                                    <Tooltip title="Delete">
                                        <Fab color="error" size="small" style={{ transform: 'scale(0.7)' , }} aria-label="checklist">
                                        <DeleteIcon  />
                                        </Fab>
                                    </Tooltip>
                                </CardActions>
                            </Card>
                        </Grid>
                        <Grid item  >
                            <Card  sx={{ height: 160,width: 250}}>
                                <CardContent>
                                    <Typography variant="h5" component="div">
                                    پروژه یادگیری عمیق
                                    </Typography>
                                    <Typography variant="body2">
                                    این لیست برای پروژه درس یادگیری عمیق طراحی شده است.
                                    </Typography>
                                </CardContent>
                                <CardActions>
                                    <Tooltip title="Open">
                                        <Fab color="success" size="small" style={{ transform: 'scale(0.7)',}} aria-label="open" >
                                        <OpenInFullIcon  />
                                        </Fab>
                                    </Tooltip>
                                    <Tooltip title="Delete">
                                        <Fab color="error" size="small" style={{ transform: 'scale(0.7)' , }} aria-label="checklist">
                                        <DeleteIcon  />
                                        </Fab>
                                    </Tooltip>
                                </CardActions>
                            </Card>
                        </Grid>
                        
                    </Grid>
                </Grid>
            </Grid>
            
        </Layout>
    );
}

export {
    ListofLists,
}