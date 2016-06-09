//
//  MDPCheckInHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 29/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPCheckInHandlerProtocol_h
#define MDPClient_MDPCheckInHandlerProtocol_h

#import "MDPPagedCheckInsModel.h"
#import "MDPPagedCheckInTypeModel.h"


#pragma mark - Response
typedef void (^MDPCheckInHandlerResponseBlock)(NSArray *response, NSError *error);


@protocol MDPCheckInHandlerProtocol <NSObject>

/**
 Gets the paginated list of places availables for check-in.
 */
+ (void)getPlacesWithCt:(uint)ct
               language:(NSString *)language
        completionBlock:(void(^)(MDPPagedCheckInTypeModel *content, NSError *error))completionBlock;

/*
 Gets a checkin type by his id
 */
+ (void)getCheckinTypeByIdWithCheckInType:(NSString *)checkIntype
                                 language:(NSString *)language
                          completionBlock:(void(^)(MDPCheckInTypeModel *content, NSError *error))completionBlock;


/*
 Gets the paginated list of a fan check-in.
 */
+ (void)getFanCheckinsWithContinuationToken:(NSString *)continuationToken
                            completionBlock:(void(^)(MDPPagedCheckInsModel *content, NSError *error))completionBlock;

/*
 Sends a check-in
 */
+ (void)postFanCheckinWithIdCheckInType:(NSString *)idCheckInType
                            latitude:(double)latitude
                           longitude:(double)longitude
                            altitude:(double)altitude
                     completionBlock:(void(^)(MDPCheckInModel *content, NSError *error))completionBlock;


/*
 Listens to MDPCheckInModel objects. Return the elements order for checkin date
 */
+ (NSFetchedResultsController *)checkInFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;
+ (NSFetchedResultsController *)checkInTypeFetchedResultsControllerWithDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
#endif
