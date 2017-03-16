//
//  _MDPPagedVirtualGoodTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPagedVirtualGoodTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPagedVirtualGoodTypeModelAttributes {
	__unsafe_unretained NSString *currentPage;
	__unsafe_unretained NSString *hasMoreResults;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *pageCount;
	__unsafe_unretained NSString *pageSize;
	__unsafe_unretained NSString *totalItems;
} MDPPagedVirtualGoodTypeModelAttributes;

extern const struct MDPPagedVirtualGoodTypeModelRelationships {
	__unsafe_unretained NSString *pagedVirtualGoodTypeRequest;
	__unsafe_unretained NSString *results;
} MDPPagedVirtualGoodTypeModelRelationships;

@class MDPPagedVirtualGoodTypeRequestModel;
@class MDPVirtualGoodTypeModel;

@interface _MDPPagedVirtualGoodTypeModel : NSManagedObject

@property (nonatomic, strong) NSNumber* currentPage;

@property (atomic) int64_t currentPageValue;
- (int64_t)currentPageValue;
- (void)setCurrentPageValue:(int64_t)value_;

//- (BOOL)validateCurrentPage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasMoreResults;

@property (atomic) BOOL hasMoreResultsValue;
- (BOOL)hasMoreResultsValue;
- (void)setHasMoreResultsValue:(BOOL)value_;

//- (BOOL)validateHasMoreResults:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageCount;

@property (atomic) int64_t pageCountValue;
- (int64_t)pageCountValue;
- (void)setPageCountValue:(int64_t)value_;

//- (BOOL)validatePageCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* pageSize;

@property (atomic) int64_t pageSizeValue;
- (int64_t)pageSizeValue;
- (void)setPageSizeValue:(int64_t)value_;

//- (BOOL)validatePageSize:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* totalItems;

@property (atomic) int64_t totalItemsValue;
- (int64_t)totalItemsValue;
- (void)setTotalItemsValue:(int64_t)value_;

//- (BOOL)validateTotalItems:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedVirtualGoodTypeRequestModel *pagedVirtualGoodTypeRequest;

//- (BOOL)validatePagedVirtualGoodTypeRequest:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *results;

- (NSMutableOrderedSet*)resultsSet;

@end

@interface _MDPPagedVirtualGoodTypeModel (ResultsCoreDataGeneratedAccessors)
- (void)addResults:(NSOrderedSet*)value_;
- (void)removeResults:(NSOrderedSet*)value_;
- (void)addResultsObject:(MDPVirtualGoodTypeModel*)value_;
- (void)removeResultsObject:(MDPVirtualGoodTypeModel*)value_;
@end

@interface _MDPPagedVirtualGoodTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSNumber*)primitiveCurrentPage;
- (void)setPrimitiveCurrentPage:(NSNumber*)value;

- (int64_t)primitiveCurrentPageValue;
- (void)setPrimitiveCurrentPageValue:(int64_t)value_;

- (NSNumber*)primitiveHasMoreResults;
- (void)setPrimitiveHasMoreResults:(NSNumber*)value;

- (BOOL)primitiveHasMoreResultsValue;
- (void)setPrimitiveHasMoreResultsValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePageCount;
- (void)setPrimitivePageCount:(NSNumber*)value;

- (int64_t)primitivePageCountValue;
- (void)setPrimitivePageCountValue:(int64_t)value_;

- (NSNumber*)primitivePageSize;
- (void)setPrimitivePageSize:(NSNumber*)value;

- (int64_t)primitivePageSizeValue;
- (void)setPrimitivePageSizeValue:(int64_t)value_;

- (NSNumber*)primitiveTotalItems;
- (void)setPrimitiveTotalItems:(NSNumber*)value;

- (int64_t)primitiveTotalItemsValue;
- (void)setPrimitiveTotalItemsValue:(int64_t)value_;

- (MDPPagedVirtualGoodTypeRequestModel*)primitivePagedVirtualGoodTypeRequest;
- (void)setPrimitivePagedVirtualGoodTypeRequest:(MDPPagedVirtualGoodTypeRequestModel*)value;

- (NSMutableOrderedSet*)primitiveResults;
- (void)setPrimitiveResults:(NSMutableOrderedSet*)value;

@end
