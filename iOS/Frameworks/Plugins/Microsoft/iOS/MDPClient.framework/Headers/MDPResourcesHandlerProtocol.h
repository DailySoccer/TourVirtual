//
//  MDPResourcesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 18/8/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPResourcesHandlerProtocol_h
#define MDPClient_MDPResourcesHandlerProtocol_h

#import "MDPResourceVersionModel.h"
#import "MDPResourceModel.h"


#pragma mark - Response
typedef void (^MDPResourcesHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPResourcesHandlerProtocol
@protocol MDPResourcesHandlerProtocol <NSObject>

/*
 Get the current version number of the resources file for an app.
 */
+ (void)getCurrenVersionNumberResourcesByAppWithMajor:(int)major
                                      completionBlock:(void(^)(MDPResourceVersionModel *content, NSError *error))completionBlock;


/*
 Get metadata info and stream of resource file for a version.
 */
+ (void)getResourcesFileByVersionWithMajor:(int)major
                                     minor:(int)minor
                           completionBlock:(void(^)(MDPResourceModel *content, NSError *error))completionBlock;

@end

#endif
