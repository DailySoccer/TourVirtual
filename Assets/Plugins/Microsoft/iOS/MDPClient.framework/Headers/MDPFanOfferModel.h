//
//  MDPFanOfferModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPFanOfferModel.h"


#pragma mark - Interface
@interface MDPFanOfferModel : _MDPFanOfferModel

+ (MDPFanOfferModel *)fanOfferithIdOfferType:(NSString *)idOfferType managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsFanOfferWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

@end
