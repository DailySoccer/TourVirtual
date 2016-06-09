//
//  MDPAdvertisementHandlerProtocol.h
//  MDPClient
//
//  Created by Ernesto Fernández Calles on 23/01/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPAdvertisementHandlerProtocol_h
#define MDPClient_MDPAdvertisementHandlerProtocol_h

#pragma mark - Model
#import "MDPAdvertisementModel.h"


#pragma mark - Response
typedef void (^MDPAdvertisementHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPAdvertisementHandlerProtocol
@protocol MDPAdvertisementHandlerProtocol <NSObject>

/*
 Get an Advertisement entity filtering by its unique identifier and a language.
 */
+ (void)getAdvertisementWithIdAdvertisement:(NSString *)idAdvertisement
                                   language:(NSString *)language
                            completionBlock:(void(^)(MDPAdvertisementModel *content, NSError *error))completionBlock;

@end

#endif