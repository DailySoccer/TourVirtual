//
//  MDPAdvertisementModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPAdvertisementModel.h"

#pragma mark  - AdNavigationType
typedef NS_ENUM(NSInteger, MDPAdvertisementModelAdNavigationType) {
    MDPAdvertisementModelAdNavigationTypeInternal   = 0,
    MDPAdvertisementModelAdNavigationTypeExternal   = 1,
};


#pragma mark - Interface
@interface MDPAdvertisementModel : _MDPAdvertisementModel

+ (MDPAdvertisementModel *)advertisementWithId:(NSString *)idAdvertisement managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsAdvertisementWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
