//
//  _MDPUserVideoRatingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPUserVideoRatingModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPUserVideoRatingModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *rating;
	__unsafe_unretained NSString *videoId;
} MDPUserVideoRatingModelAttributes;

extern const struct MDPUserVideoRatingModelRelationships {
	__unsafe_unretained NSString *pagedVideoRatingResults;
} MDPUserVideoRatingModelRelationships;

@class MDPPagedVideoRatingModel;

@interface _MDPUserVideoRatingModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDecimalNumber* rating;

//- (BOOL)validateRating:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* videoId;

//- (BOOL)validateVideoId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedVideoRatingModel *pagedVideoRatingResults;

//- (BOOL)validatePagedVideoRatingResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPUserVideoRatingModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDecimalNumber*)primitiveRating;
- (void)setPrimitiveRating:(NSDecimalNumber*)value;

- (NSString*)primitiveVideoId;
- (void)setPrimitiveVideoId:(NSString*)value;

- (MDPPagedVideoRatingModel*)primitivePagedVideoRatingResults;
- (void)setPrimitivePagedVideoRatingResults:(MDPPagedVideoRatingModel*)value;

@end
