# Live Project

# Intro

This is my live project I worked on while attending the tech academy. Some of it is simple UI changes on the site, and mostly front end work.
I had alot of fun working on this project, as it introduced me how to work as a team with 3 other people, and how to focus on
developing with cshtml, and the MVC structure. The point of this project is to focus on "user stories" which are customer
requests about a specific feature on the site, and I had the pleasurre of getting to fix them. We also got to use legacy code, as most of
the sites layout was completed, and we got the opportunity to add features of our own.
Unfortunately I cannot include the entire source code due to client request.
I'm happy to show what I've done so far, and you may see this expand in the future.

## Wishlist Hover

For this story, I had to add a hover overlay to the thumbnail on the wishlist index page, if the campaign was going to expire within 5 days. So I used css and designed a hover effect for it to display meeting that logic. I created an image container to nest the thumbnail image in to execute on hover, which also displays the middle text.

```
//css additions
.image {
    opacity: 1;
    transition: .5s ease;
    backface-visibility: hidden;
}
.image-container {
    position: relative;
    width: 100%;
}
.middle {
    transition: .5s ease;
    opacity: 0;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    -ms-transform: translate(-50%, -50%);
    text-align: center;
}
.image-container:hover .image {
    opacity: 0.3;
}
.image-container:hover .middle {
    opacity: 1;
}
.text {
    color: black;
    font-size: 12px;
    padding: 16px 32px;
    font-weight: 600;
}
```
next I added some logic to the index page for determining whether or not to apply that hover effect using an if statement.

```
\\before
              if (!item.Campaign.IsExpired)
                {
              <tr>
                 <td class="td-valign">
                  <img src="@item.Campaign.ImageUrL" class="imgThumb" />
                 </td>
                 <td class="td-valign">
                     @Html.DisplayFor(modelItem => item.Campaign.Name)
                  </td>
                  <td class="td-valign">
                      @Html.DisplayFor(modelItem => item.Campaign.SalePrice)
                  </td>
                  <td class="td-valign">
                      @Html.DisplayFor(modelItem => item.Campaign.CloseDate)
                  </td>
                  <td class="td-valign">
                      <a href="@item.Campaign.VendorsPurchaseURL" target="_blank">See on Amazon</a>
                  </td>
                  <td class="td-valign">
                          @Html.ActionLink("Remove from Wishlist ", "Delete", new { id = item.WishlistId })
                  </td>
              </tr>
                  }
              
```
```
\\after
         if (!item.Campaign.IsExpired)
            {
         <tr>
            @if (item.Campaign.RemainingTime < new TimeSpan(6, 0, 0, 0))
            {
            <td class="td-valign">
                <div class="image-container">
                    <img src="@item.Campaign.ImageUrL" class="imgThumb image" />
                    <div class="middle">
                        <div class="text">Expiring in within 5 days</div>
                    </div>
                </div>
            </td>
            }
            else{
            <td class="td-valign">
                <img src="@item.Campaign.ImageUrL" class="imgThumb" />
            </td>
             }
            <td class="td-valign">
                @Html.DisplayFor(modelItem => item.Campaign.Name)
            </td>
            <td class="td-valign">
                @Html.DisplayFor(modelItem => item.Campaign.SalePrice)
            </td>
            <td class="td-valign">
                @Html.DisplayFor(modelItem => item.Campaign.CloseDate)
            </td>
            <td class="td-valign">
                <a href="@item.Campaign.VendorsPurchaseURL" target="_blank">See on Amazon</a>
            </td>
            <td class="td-valign">
                    @Html.ActionLink("Remove from Wishlist ", "Delete", new { id = item.WishlistId })
            </td>
        </tr>
            }
  ```
  
  I used the Remainingtime method which calculates how many days are left in a campaigns promotion discount period, along with Timespan, to only execute when its expiring within 5 days.  
  
  ![screenshot 42 _li](https://user-images.githubusercontent.com/38439646/43030227-936aac24-8c42-11e8-900d-371115347869.jpg)

 

## Review stars fill in

So this one was interesting. My job was to have the stars exactly match the average score of the product, so essentially the star was going to portray the score accurately on the review index page. Before I changed the code, the star would only fill 1/5 , 2/5 etc. 

```
\\before 

@foreach (var item in Model)

    {
        <div class="accordion-review-item">

            <div class="row">
                <div class="col-sm-12">
                    <img class="imgThumb" src="@item.Campaign.ImageUrL" alt="@item.Campaign.Name" />
                    @Html.DisplayFor(modelItem => item.Campaign.Name) |

@for (int i = 0; i < item.ReviewAverage; i++)
                    {
                     <div class="star-rating__wrap ">
                            <span style="cursor:default" class="star-rating__ico fa fa-star fa-lg" title="@item.ReviewAverage out of 5 stars" value: @item.ReviewAverage></span>
                      </div>
                     }
```

```
\\after
@foreach (var item in Model)

    {
        <div class="accordion-review-item">

            <div class="row">
                <div class="col-sm-12">
                    <img class="imgThumb" src="@item.Campaign.ImageUrL" alt="@item.Campaign.Name" />
                    @Html.DisplayFor(modelItem => item.Campaign.Name) |
                        
                    
                        <div class="stars-outer" title="@item.ReviewAverage out of 5 stars">
                            <div class="stars-inner" style="width:@(item.ReviewAverage*20)%;"></div>
                        </div>
                    

```

![screenshot 48](https://user-images.githubusercontent.com/38439646/43031010-f957f996-8c4d-11e8-987a-798acb7b84a1.png)


## ViewBag Title change 

This one was pretty straight forward, the objective was to switch the Viewbag Title to the first name of the user instead of edit, on the edit page for the admin controller,
as well as to remove the AdminViewModel h4 tag

```
\\before 
@model BlueRibbonsReview.ViewModels.AdminViewModel
@{
    ViewBag.Title = "Edit";
}
@*<h2>Edit</h2>*@
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>AdminViewModel</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">

```
```
\\after
@model BlueRibbonsReview.ViewModels.AdminViewModel
@{
    ViewBag.Title = Model.FirstName;
}
@*<h2>Edit</h2>*@
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">

```

![screenshot 49 _li](https://user-images.githubusercontent.com/38439646/43031060-f4564ed8-8c4e-11e8-902b-d85d1a714542.jpg)



## Change Buyer dashboard link

The problem on this story, was that for a buyer on the site, when they would click "campaigns" it would take them to the sellerindex page instead of the campaign index page. So to remedy that, I just changed the hmtl actionlink to index instead of seller index

```
\\before

 <li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Buyer                Dashboard <span class="caret"></span></a>
        <ul class="dropdown-menu">
            <li>@Html.ActionLink("Campaigns", "SellerIndex", "Campaigns")</li>
            <li>@Html.ActionLink("Reviews", "ReviewIndex", "Reviews")</li>
            <li>
                <a href="@Url.Action("Index", "Wishlist")">Wishlist <i class="fas fa-shopping-cart">(@Model.WishlistLength)</i></a>



```

```
\\after 

<li class="dropdown">
        <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Buyer                Dashboard <span class="caret"></span></a>
        <ul class="dropdown-menu">
            <li>@Html.ActionLink("Campaigns", "Index", "Campaigns")</li>
            <li>@Html.ActionLink("Reviews", "ReviewIndex", "Reviews")</li>
            <li>
                <a href="@Url.Action("Index", "Wishlist")">Wishlist <i class="fas fa-shopping-cart">(@Model.WishlistLength)</i></a>


```
### Before click

![screenshot 52](https://user-images.githubusercontent.com/38439646/43031096-d053c140-8c4f-11e8-83fa-2af293d49754.png)


### After click 

![screenshot 53](https://user-images.githubusercontent.com/38439646/43031109-ef2192d2-8c4f-11e8-85e1-c176ec81f74d.png)

## Remove excess width from sidebar 

For this it was all CSS changes to be made, the problem was is the the padding was too much so I shortened it, as well adjusted the height pixel count to 100px , and width to 125px. 

```
\\before

#wrapper.toggled #sidebar-wrapper {
        width: 220px;
    }
 .sidebar-nav .my-navbar {
        position: absolute;
        top: 0;
        height: 100%;
        width: 200px;
        margin: 0;
        padding: 0;
        list-style: none;
            display: block;
            color: #fff;
            text-decoration: none;
            padding: 10px 15px 10px 30px;

        }

```

```

\\after
 #wrapper.toggled #sidebar-wrapper {
        width: 125px;
    }
    
    .sidebar-nav .my-navbar {
        position: absolute;
        top: 0;
        width: 200px;
        height:100px;
        margin: 0;
        padding: 0;
        list-style: none;
            display: block;
            color: #fff;
            text-decoration: none;
            padding: 10px  ;
        }


```

![screenshot 54](https://user-images.githubusercontent.com/38439646/43031199-a5d45aea-8c51-11e8-9bdc-0b635f25a59b.png)

So thats a wrap so far for my user stories completed. This project has taught me what its like to work with a team. We used visual studio and TFS to do this project, and I work with 2 other awesome developers doing this project. Thanks for having a look.
