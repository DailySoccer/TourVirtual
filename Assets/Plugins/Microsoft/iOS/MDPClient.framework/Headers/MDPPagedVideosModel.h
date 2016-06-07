//
//  MDPPagedVideosModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPagedVideosModel.h"
#import "MDPVideoModel.h"


#pragma mark - Interface
@interface MDPPagedVideosModel : _MDPPagedVideosModel

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary
                            callType:(MDPVideoModelCallType)callType
                managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPPagedVideosModel *)pagedVideosWithCallType:(MDPVideoModelCallType)callType
                                   managedObjectContext:(NSManagedObjectContext *)context;

@end
