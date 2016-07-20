//
//  MDPMatchSubscriptionInformationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPMatchSubscriptionInformationModel.h"


#pragma mark - Interface
@interface MDPMatchSubscriptionInformationModel : _MDPMatchSubscriptionInformationModel

+ (instancetype)insertIfNotExistsMatchSubscriptionInformationWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
