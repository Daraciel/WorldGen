using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using Emgu.CV;
using Emgu.CV.Structure;


namespace MapLabelling
{
    public class MassLabelling
    {
        private int[] no_of_labels;
        private int[,] eqMat;
        private int cnt;
        public region_props[] rp;

        public MassLabelling()
        {
            no_of_labels = new int[50];
            eqMat = new int[50, 50];
            rp = new region_props[50];
            cnt = 0;
        }

        private int check_label(int value)
        {
            int i;
            for (i = 0; i < cnt; i++)
            {
                if (no_of_labels[i] == value)
                    return 0;
            }
            return 1;
        }

        private void add_to_labels(int value)
        {
            int success_flag;
            success_flag = check_label(value);
            if (success_flag == 1)
            {
                no_of_labels[cnt] = value;
                cnt++;
            }
        }

        private void equivalance_matrix(int row_no, int col_no)
        {
            eqMat[row_no,col_no] = 1;
            eqMat[col_no,row_no] = 1;
        }

        public void regionprops(MIplImage img)
        {
            int i,j;
	        for(i=0;i<50;i++)
	        {
		        for(j=0;j<50;j++)
		        {
			        eqMat[i,j]=0;		
		        }
	        }

	        //IplImage *img = cvLoadImage("I:/test.bmp",0);
	        int h1=img.height;
            int w1=img.width;
            Int32 ul;
            float varf;

	        float var,var1,var2,var3,var4;
	        //unsigned long ul;
	        int x;
	        int label=0;
        ///////////////////////////////////////////////////////////////////////
	        //fill the first row, first column, last row, last column by 0
	        for(i=0;i<w1;i++)
	        {
                
		        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,0,i,0); 
		        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,(h1-1),i,0); 
	        }
	
	        for(i=0;i<h1;i++)
	        {
		        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,0,0); 
		        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,(w1-1),0); 
	        }
        ///////////////////////////////////////////////////////////////////////
        for(i=0;i<h1;i++)
        {
	        for(j=0;j<w1;j++)
	        {
		        varf=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i,j);
		        ul=(Int32)varf;
		        //printf("   %d",  ul);
	        }
	        //printf("\n");
        }

	        for(i=1;i<h1;i++)
	        {
		        for(j=1;j<w1;j++)
		        {
			        var=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i,j);
			        ul=(Int32)var;			
			        x=ul;
			        if(i==2)
			        //printf("\n i=%d j=%d",i,j);
			        if(x!=0)
			        {
				        var1=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i,j-1);
				        var2=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i-1,j-1);
				        var3=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i-1,j);
				        var4=(float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData,i-1,j+1);
				        int cnt=0;
				        if(var1!=0)
				        {
					        cnt++;
					        //cvSetReal2D(img,i,j,var1);
				        }
				        if(var2!=0)
				        {
					        cnt++;
					        //cvSetReal2D(img,i,j,var2); 
				        }
				        if(var3!=0)
				        {
					        cnt++;
					        //cvSetReal2D(img,i,j,var3); 
				        }
				        if(var4!=0)
				        {
					        cnt++;
					        //cvSetReal2D(img,i,j,var4); 
				        }
				        if(cnt==0)
				        {
					        //central pixel non zero & neighbours zero
					        label++;
					        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,label); 
				        }
				        if(cnt==1)
				        {
					        // one neighbour is non zero
					        if(var1!=0)
					        {
						        if(var1!=255)
						        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var1); 
						        else
						        {
							        // 
						        }
					        }
					        else
					        {
						        if(var2!=0)
						        {
							        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var2); 
						        }
						        else
						        {
							        if(var3!=0)
							        {
								        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var3); 
							        }
							        else
							        {
								        if(var4!=0)
								        {
									        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var4); 
								        }
							        }
						        }
					        }
				        }
				        if(cnt>=2)
				        {
					        // more than two elements are non zero fill the equivalance matrix.
					        Int32 middle_pixel;
					        middle_pixel=-1;
					        if(var1!=0)
					        {
						        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var1); 
						        middle_pixel=(Int32)var1;
					        }
					        else
					        {
						        if(var2!=0)
						        {
							        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var2);
                                    middle_pixel = (Int32)var2;
						        }
						        else
						        {
							        if(var3!=0)
							        {
								        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var3);
                                        middle_pixel = (Int32)var3;
							        }
							        else
							        {
								        if(var4!=0)
								        {
									        Emgu.CV.CvInvoke.cvSetReal2D(img.imageData,i,j,var4);
                                            middle_pixel = (Int32)var4;
								        }
							        }
						        }
					        }

					        // do entry in equivalance matrix.
					        if(middle_pixel!=var1 && var1!=0 && var1!=255)
					        {
						        equivalance_matrix(middle_pixel,(Int32)var1);
					        }
					        if(middle_pixel!=var2 && var2!=0 && var2!=255)
					        {
						        equivalance_matrix(middle_pixel,(Int32)var2);
					        }
					        if(middle_pixel!=var3 && var3!=0 && var3!=255)
					        {
						        equivalance_matrix(middle_pixel,(Int32)var3);
					        }
					        if(middle_pixel!=var4 && var4!=0 && var4!=255)
					        {
						        equivalance_matrix(middle_pixel,(Int32)var4);
					        }
				        }


			        }
		        }
	        }

        //printf("\n\n\n\n\n");
        for(i=0;i<10;i++)
        {
	        for(j=0;j<10;j++)
	        {
			        //printf(" %d", eqMat[i,j] );
	        }
	        //printf("\n");
        }
	


        int k;

	        for(j=0;j<50;j++)
	        {
		        for(i=0;i<50;i++)
		        {
			        if(eqMat[i,j]==1)
			        {
				        for(k=1;k<50;k++)
				        {
					        eqMat[i,k]=eqMat[i,k];
					        eqMat[i,k]=eqMat[j,k];
				        }
			        }
			        if(i==j) // set digonal to 1
				        eqMat[i,j]=1; 
		        }
	        }







        //printf("\n\n\n\n\n");
        for(i=0;i<10;i++)
        {
	        for(j=0;j<10;j++)
	        {
			        //printf(" %d", eqMat[i,j] );
	        }
	        //printf("\n");
        }

        //printf("\nB4 replacement \n\n\n\n");
        for(i=0;i<h1;i++)
        {
	        for(j=0;j<w1;j++)
	        {
                varf = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, i, j);
                ul = (Int32)varf;
		        //printf("   %d",  ul);
	        }
	        //printf("\n");
        }

        int rw, col;

        for(i=5;i>=0;i--)
        {
	        for(j=5;j>=0;j--)
	        {
		        if(eqMat[i,j]==1)
		        {
			        if(i<j)
			        {
				        for(rw=0;rw<h1;rw++)
				        {
					        for(col=0;col<w1;col++)
					        {
						        //find j in image & replace it with i
                                var = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, rw, col);
						        ul=(Int32) var;
						        if(var==j)
						        {
                                    Emgu.CV.CvInvoke.cvSetReal2D(img.imageData, rw, col, i); 
						        }

					        }
				        }
			        }
			        else
			        {
				        if(i>j)
				        {
				        for(rw=0;rw<h1;rw++)
				        {
					        for(col=0;col<w1;col++)
					        {
						        //find i in image & replace it with j
                                var = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, rw, col);
						        ul=(Int32) var;
						        if(var==i)
						        {
                                    Emgu.CV.CvInvoke.cvSetReal2D(img.imageData, rw, col, j); 
						        }

					        }
				        }
				        }
			        }
		        }
	        }
        }

        //printf("\n\n\n\n\n");
        for(i=0;i<h1;i++)
        {
	        for(j=0;j<w1;j++)
	        {
                varf = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, i, j);
		        ul=(Int32)varf;
		        //printf("   %d",  ul);
	        }
	        //printf("\n");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        // region props
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        for(i=0;i<h1;i++)
        {
	        for(j=0;j<w1;j++)
	        {
                varf = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, i, j);
		        ul=(Int32)varf;	
		        if(ul!=0)
		        {
			        add_to_labels(ul);
		        }
	        }
        }

        //printf("\n\n\n\n\n");

        //printf("\n No of labels are =%d", cnt);

        for(i=0;i<cnt;i++)
        {
	       // printf("   %d",no_of_labels[i]);
        }

        // find out the count for each of the label...
        int struct_index=0,l,m;

        for(i=0;i<cnt;i++)
        {
	        for(l=1;l<h1;l++)  
	        {
		        for(m=1;m<w1;m++)
		        {
                    varf = (float)Emgu.CV.CvInvoke.cvGetReal2D(img.imageData, l, m);
			        ul=(Int32)varf;	
			        if(ul==no_of_labels[i])
			        {
				        rp[struct_index].area ++;
				        rp[struct_index].value=ul;   
				        rp[struct_index].x+= l;
				        rp[struct_index].y+= m;
			        }
		        }
	        }
	        struct_index ++;
        }


        //printf("\n\n\n\n\n");

        for(i=0;i<cnt;i++)
        {
	        //printf("\n label is=%d, Area is=%d  Centroid is (x=%f,y=%f) ",rp[i].value,rp[i].area,(rp[i].x/rp[i].area),(rp[i].y/rp[i].area));
        }


        }

    }
}
